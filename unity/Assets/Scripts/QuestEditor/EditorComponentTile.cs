﻿using UnityEngine;
using System.Text;
using System.Collections.Generic;
using Assets.Scripts.Content;
using Assets.Scripts.UI;

public class EditorComponentTile : EditorComponent
{
    QuestData.Tile tileComponent;

    public EditorComponentTile(string nameIn) : base()
    {
        Game game = Game.Get();
        tileComponent = game.quest.qd.components[nameIn] as QuestData.Tile;
        component = tileComponent;
        name = component.sectionName;
        Update();
    }
    
    override public float AddSubComponents(float offset)
    {
        Game game = Game.Get();
        CameraController.SetCamera(tileComponent.location);

        UIElement ui = new UIElement(Game.EDITOR, scrollArea.GetScrollTransform());
        ui.SetLocation(0, offset, 4.5f, 1);
        ui.SetText(new StringKey("val", "X_COLON", new StringKey("val", "IMAGE")));

        ui = new UIElement(Game.EDITOR, scrollArea.GetScrollTransform());
        ui.SetLocation(4.5f, offset, 15, 1);
        ui.SetText(tileComponent.tileSideName);
        ui.SetButton(delegate { ChangeTileSide(); });
        new UIElementBorder(ui);
        offset += 2;

        ui = new UIElement(Game.EDITOR, scrollArea.GetScrollTransform());
        ui.SetLocation(0, offset, 4, 1);
        ui.SetText(new StringKey("val", "X_COLON", CommonStringKeys.POSITION));

        ui = new UIElement(Game.EDITOR, scrollArea.GetScrollTransform());
        ui.SetLocation(4, offset, 4, 1);
        ui.SetText(CommonStringKeys.POSITION_SNAP);
        ui.SetButton(delegate { GetPosition(); });
        new UIElementBorder(ui);
        offset += 2;

        ui = new UIElement(Game.EDITOR, scrollArea.GetScrollTransform());
        ui.SetLocation(0, offset, 6, 1);
        ui.SetText(new StringKey("val", "X_COLON", new StringKey("val", "ROTATION")));

        ui = new UIElement(Game.EDITOR, scrollArea.GetScrollTransform());
        ui.SetLocation(6, offset, 3, 1);
        ui.SetText(tileComponent.rotation.ToString());
        ui.SetButton(delegate { TileRotate(); });
        new UIElementBorder(ui);
        offset += 2;

        game.tokenBoard.AddHighlight(tileComponent.location, "TileAnchor", Game.EDITOR);

        game.quest.ChangeAlpha(tileComponent.sectionName, 1f);

        return offset;
    }

    public void ChangeTileSide()
    {
        if (GameObject.FindGameObjectWithTag(Game.DIALOG) != null)
        {
            return;
        }
        Game game = Game.Get();
        UIWindowSelectionListTraits select = new UIWindowSelectionListTraits(SelectTileSide, new StringKey("val", "SELECT", CommonStringKeys.TILE));

        // Work out what sides are used
        HashSet<string> usedSides = new HashSet<string>();
        foreach (KeyValuePair<string, QuestData.QuestComponent> kv in game.quest.qd.components)
        {
            QuestData.Tile t = kv.Value as QuestData.Tile;
            if (t != null)
            {
                usedSides.Add(t.tileSideName);
                usedSides.Add(game.cd.tileSides[t.tileSideName].reverse);
            }
        }

        foreach (KeyValuePair<string, TileSideData> kv in game.cd.tileSides)
        {
            Dictionary<string, IEnumerable<string>> traits = new Dictionary<string, IEnumerable<string>>();

            List<string> sets = new List<string>();
            foreach (string s in kv.Value.sets)
            {
                if (s.Length == 0)
                {
                    sets.Add(new StringKey("val", "base").Translate());
                }
                else
                {
                    sets.Add(new StringKey("val", s).Translate());
                }
            }
            traits.Add(new StringKey("val", "EXPANSION").Translate(), sets);

            List<string> traitlocal = new List<string>();
            foreach (string s in kv.Value.traits)
            {
                traitlocal.Add(new StringKey("val", s).Translate());
            }
            traits.Add(new StringKey("val", "TRAITS").Translate(), traitlocal);

            Color buttonColor = Color.white;
            if (usedSides.Contains(kv.Key))
            {
                buttonColor = Color.grey;
            }

            select.AddItem(kv.Value.name.Translate(), kv.Key, traits, buttonColor);
        }

        select.Draw();
    }

    public void SelectTileSide(string tile)
    {
        Game game = Game.Get();
        tileComponent.tileSideName = tile.Split(" ".ToCharArray())[0];
        game.quest.Remove(tileComponent.sectionName);
        game.quest.Add(tileComponent.sectionName);
        Update();
    }

    public void TileRotate()
    {
        if (tileComponent.rotation == 0)
        {
            tileComponent.rotation = 90;
        }
        else if (tileComponent.rotation > 0 && tileComponent.rotation <= 100)
        {
            tileComponent.rotation = 180;
        }
        else if (tileComponent.rotation > 100 && tileComponent.rotation <= 190)
        {
            tileComponent.rotation = 270;
        }
        else
        {
            tileComponent.rotation = 0;
        }

        Game game = Game.Get();
        game.quest.Remove(tileComponent.sectionName);
        game.quest.Add(tileComponent.sectionName);

        Update();
    }
}

﻿namespace OggVorbisEncoder.Setup.Templates.Stereo44.BookBlocks.Chapter4
{
    public class Page9_1 : IStaticCodeBook
    {
        public int AllocedP = 0;
        public int Dimensions = 2;

        public byte[] LengthList = {
            1, 4, 4, 5, 5, 7, 7, 9, 8, 10, 9, 10, 10, 10, 10, 6,
            5, 5, 7, 7, 9, 8, 10, 9, 11, 10, 12, 12, 13, 13, 6, 5,
            5, 7, 7, 9, 9, 10, 10, 11, 11, 12, 12, 12, 13, 19, 8, 8,
            8, 8, 9, 9, 10, 10, 12, 11, 12, 12, 13, 13, 19, 8, 8, 8,
            8, 9, 9, 11, 11, 12, 12, 13, 13, 13, 13, 19, 12, 12, 9, 9,
            11, 11, 11, 11, 12, 11, 13, 12, 13, 13, 18, 12, 12, 9, 9, 11,
            10, 11, 11, 12, 12, 12, 13, 13, 14, 19, 18, 18, 11, 11, 11, 11,
            12, 12, 13, 12, 13, 13, 14, 14, 16, 18, 18, 11, 11, 11, 10, 12,
            11, 13, 13, 13, 13, 13, 14, 17, 18, 18, 14, 15, 11, 12, 12, 13,
            13, 13, 13, 14, 14, 14, 18, 18, 18, 15, 15, 12, 10, 13, 10, 13,
            13, 13, 13, 13, 14, 18, 17, 18, 17, 18, 12, 13, 12, 13, 13, 13,
            14, 14, 16, 14, 18, 17, 18, 18, 17, 13, 12, 13, 10, 12, 12, 14,
            14, 14, 14, 17, 18, 18, 18, 18, 14, 15, 12, 12, 13, 12, 14, 14,
            15, 15, 18, 18, 18, 17, 18, 15, 14, 12, 11, 12, 12, 14, 14, 14,
            15
        };

        public CodeBookMapType MapType = CodeBookMapType.Implicit;
        public int QuantMin = -520986624;
        public int QuantDelta = 1620377600;
        public int Quant = 4;
        public int QuantSequenceP = 0;

        public int[] QuantList = {
            7,
            6,
            8,
            5,
            9,
            4,
            10,
            3,
            11,
            2,
            12,
            1,
            13,
            0,
            14
        };
    }
}
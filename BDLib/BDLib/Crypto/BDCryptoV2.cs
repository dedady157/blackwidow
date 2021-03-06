﻿using System.Security.Cryptography;
using BDLib.Crypto.Hash;
using BDLib.Text;
using System.Text;
using System;
using System.Collections;
using BDLib.BDLibInfo;

namespace BDLib.Crypto
{
    public class BDCryptoV2
    {
        public byte[] Instructions { private get; set; }
        public BDCryptoV2(string Password, int Complexaty)
        {
            if (!Info.Moduls.Contains("Crypto/BDCryptoV2.cs"))
                Info.Moduls.Add("Crypto/BDCryptoV2.cs");

            OneKeyHasher Translator = new OneKeyHasher();

            byte[] TMPStore;

            using (SHA384Cng Seg2 = new SHA384Cng())
            using (HMACSHA384 Seg1 = new HMACSHA384(Encoding.UTF32.GetBytes(Password)))
            {
                Seg1.Initialize();
                Translator.TheHashSize = 512;
                Translator.TheCharsetUsed = Encoding.UTF8;
                TMPStore = Translator.Hash(Password);

                Seg1.TransformBlock(TMPStore, 0, TMPStore.Length, TMPStore, 0);
                Seg1.TransformBlock(TMPStore, 0, TMPStore.Length, TMPStore, 0);
                Seg1.TransformBlock(TMPStore, 0, TMPStore.Length, TMPStore, 0);
                Seg1.TransformBlock(TMPStore, 0, TMPStore.Length, TMPStore, 0);
                TMPStore = Seg1.TransformFinalBlock(TMPStore, 0, TMPStore.Length);
                TMPStore = Seg2.ComputeHash(TMPStore);
            }

            Translator.TheCharsetUsed = Encoding.Unicode;
            Translator.TheHashSize = (int)Complexaty * 10;
            TMPStore = Translator.Hash(TMPStore);

            Instructions = Translator.Hash(TMPStore);
        }
        private byte Translate(byte x, bool Decrypt, int I)
        {
            uint offset = Layers;
            byte output = x;
            //main rule if Decrypt do the reverse
            int o = 0;//tmp store
            switch (Instructions[I % Instructions.Length])
            {

                case (52):
                case (180):
                case (250):
                case (164):
                case (132):
                case (4):
                case (34):
                case (97):
                case (72):
                case (124):
                case (103):
                    //do nothing
                    break;

                case (210):
                case (199):
                case (127):
                case (220):
                case (176):
                case (5):
                case (253):
                case (168):
                case (48):
                case (234):
                case (175):
                case (110):
                case (222):
                case (66):
                case (64):
                case (51):
                case (232):
                    output = (Decrypt) ? ByteHelpers.ByteStepDownTranslator[output] : ByteHelpers.ByteStepUpTranslator[output];
                    output = (Decrypt) ? ByteHelpers.ByteStepDownTranslator[output] : ByteHelpers.ByteStepUpTranslator[output];
                    output = (Decrypt) ? ByteHelpers.ByteStepDownTranslator[output] : ByteHelpers.ByteStepUpTranslator[output];
                    break;

                case (25):
                case (17):
                case (98):
                case (229):
                case (196):
                case (23):
                case (236):
                case (71):
                case (105):
                case (239):
                case (181):
                case (193):
                case (45):
                case (91):
                case (113):
                case (108):
                case (87):
                case (43):
                case (198):
                case (214):
                case (59):
                case (47):
                case (161):
                case (252):
                case (130):
                    output = (Decrypt) ? ByteHelpers.ByteStepDownTranslator[output] : ByteHelpers.ByteStepUpTranslator[output];
                    output = (Decrypt) ? ByteHelpers.ByteStepDownTranslator[output] : ByteHelpers.ByteStepUpTranslator[output];
                    output = (Decrypt) ? ByteHelpers.ByteStepDownTranslator[output] : ByteHelpers.ByteStepUpTranslator[output];
                    break;

                case (118):
                case (1):
                case (101):
                case (0):
                case (225):
                case (184):
                case (238):
                case (195):
                case (114):
                case (85):
                case (246):
                case (100):
                case (99):
                case (202):
                case (67):
                case (61):
                case (207):
                case (32):
                case (50):
                case (171):
                case (84):
                case (237):
                case (126):
                case (20):
                case (138):
                case (80):
                    o = Instructions[I] * I;

                    for (; o <= 0; o--)
                    {
                        output = (Decrypt) ? ByteHelpers.ByteStepUpTranslator[output] : ByteHelpers.ByteStepDownTranslator[output];
                    }
                    break;

                case (57):
                case (54):
                case (249):
                case (133):
                case (96):
                case (115):
                case (102):
                case (122):
                case (224):
                case (231):
                case (245):
                case (68):
                case (228):
                case (123):
                case (183):
                case (36):
                case (216):
                case (116):
                case (141):
                case (219):
                case (197):
                case (28):
                case (56):
                case (140):
                case (9):
                    o = Instructions[I]*I;

                    for (; o <= 0; o--)
                    {
                        output = (Decrypt) ? ByteHelpers.ByteStepDownTranslator[output] : ByteHelpers.ByteStepUpTranslator[output];
                    }
                    break;


                
                case (119):
                case (60):
                case (18):
                case (131):
                case (242):
                case (90):
                case (40):
                case (230):
                case (104):
                case (8):
                case (205):
                case (150):
                case (157):
                case (70):
                case (178):
                case (27):
                case (107):
                case (7):
                case (95):
                case (55):
                case (31):
                case (16):
                case (160):
                case (21):
                case (145)://upstep 2
                    output = (Decrypt) ? ByteHelpers.ByteStepDownTranslator[output] : ByteHelpers.ByteStepUpTranslator[output];
                    break;


                
                case (137):
                case (63):
                case (12):
                case (106):
                case (53):
                case (179):
                case (191):
                case (254):
                case (69):
                case (241):
                case (204):
                case (235):
                case (92):
                case (88):
                case (194):
                case (11):
                case (121):
                case (35):
                case (163):
                case (33):
                case (244):
                case (29):
                case (165):
                case (208):
                case (148):
                case (151)://downstep 3
                    output = (Decrypt) ? ByteHelpers.ByteStepUpTranslator[output] : ByteHelpers.ByteStepDownTranslator[output];
                    break;
                    

                
                case (93):
                case (251):
                case (139):
                case (182):
                case (58):
                case (217):
                case (153):
                case (38):
                case (185):
                case (30):
                case (19):
                case (65):
                case (212):
                case (2):
                case (41):
                case (42):
                case (37):
                case (146):
                case (190):
                case (154):
                case (62):
                case (206):
                case (24):
                case (22):
                case (169)://add x
                    o = Instructions[I];

                    for (; o <= 0; o--)
                    {
                        output = (Decrypt) ? ByteHelpers.ByteStepDownTranslator[output] : ByteHelpers.ByteStepUpTranslator[output];
                    }
                    break;

                
                case (135):
                case (174):
                case (200):
                case (227):
                case (49):
                case (3):
                case (86):
                case (112):
                case (172):
                case (15):
                case (14):
                case (215):
                case (243):
                case (218):
                case (170):
                case (46):
                case (6):
                case (74):
                case (13):
                case (166):
                case (134):
                case (136):
                case (144):
                case (177):
                case (223):
                case (142)://minus x
                    o = Instructions[I];

                    for (; o <= 0; o--)
                    {
                        output = (Decrypt) ? ByteHelpers.ByteStepUpTranslator[output] : ByteHelpers.ByteStepDownTranslator[output];
                    }
                    break;

                
                
                case (94):
                case (240):
                case (186):
                case (201):
                case (111):
                case (189):
                case (125):
                case (248):
                case (192):
                case (44):
                case (149):
                case (143):
                case (77):
                case (129):
                case (156):
                case (221):
                case (128):
                case (255):
                case (187):
                case (167):
                case (152):
                case (82):
                case (73):
                case (159):
                case (81):
                case (109)://minus x*2
                    o = Instructions[I] * 2;

                    for (; o < 0; o--)
                    {
                        output = (Decrypt) ? ByteHelpers.ByteStepUpTranslator[output] : ByteHelpers.ByteStepDownTranslator[output];
                    }
                    break;

                
                case (79):
                case (162):
                case (26):
                case (39):
                case (203):
                case (117):
                case (155):
                case (147):
                case (213):
                case (76):
                case (158):
                case (226):
                case (75):
                case (233):
                case (78):
                case (209):
                case (247):
                case (10):
                case (89):
                case (211):
                case (173):
                case (120):
                case (188):
                case (83)://add x*2
                    o = Instructions[I] * 2;

                    for (; o < 0; o--)
                    {
                        output = (Decrypt) ? ByteHelpers.ByteStepDownTranslator[output] : ByteHelpers.ByteStepUpTranslator[output];
                    }
                    break;



                default: throw new IndexOutOfRangeException("Instruction not found");
            }

            return output;
        }
        public byte[] Compute(byte[] message, bool Decrypt)
        {
            byte[] buffer = new byte[message.Length];//this is so that we can Constantly re-set the value
            message.CopyTo(buffer, 0);
            int I = 0;

            for (int y = 0; y != Layers; y++)
            {
                for (int x = 0; x < message.Length; x++)
                {
                    buffer[x] = Translate(buffer[x], Decrypt, I);
                    I++;

                    if(Instructions.Length == I)
                    {
                        I = 0;
                    }
                }
            }

            return buffer;
        }
        public uint Layers { get; set; }
    }
}

using System.Globalization;
using Raylib_cs;
using System.Numerics;

namespace ChipSharp
{

	public class Program
	{
		//https://github.com/Timendus/chip8-test-suite
		//CHIP 8 Splash
		private static string testProgram1 = "00e0 6101 6008 a250 d01f 6010 a25f d01f 6018 a26e d01f 6020 a27d d01f 6028 a28c d01f 6030 a29b d01f 6110 6008 a2aa d01f 6010 a2b9 d01f 6018 a2c8 d01f 6020 a2d7 d01f 6028 a2e6 d01f 6030 a2f5 d01f 124e 0f02 0202 0202 0000 1f3f 71e0 e5e0 e8a0 0d2a 2828 2800 0018 b8b8 3838 3fbf 0019 a5bd a19d 0000 0c1d 1d01 0d1d 9d01 c729 2929 2700 00f8 fcce c6c6 c6c6 0049 4a49 483b 0000 0001 0303 0301 f030 9000 0080 0000 00fe c783 8383 c6fc e7e0 e0e0 e071 3f1f 0000 0702 0202 0239 3838 3838 b8b8 3800 0031 4a79 403b dddd dddd dddd dddd 0000 a038 20a0 18ce fcf8 c0d4 dcc4 c500 0030 4424 1463 f103 0707 7757 5371 0000 288e a8a8 a6ce 8703 0303 87fe fc00 0060 90f0 8070";
		//IBM Splash
		private static string testProgram2 = "00e0 a22a 600c 6108 d01f 7009 a239 d01fa248 7008 d01f 7004 a257 d01f 7008 a266d01f 7008 a275 d01f 1228 ff00 ff00 3c003c00 3c00 3c00 ff00 ffff 00ff 0038 003f003f 0038 00ff 00ff 8000 e000 e000 80008000 e000 e000 80f8 00fc 003e 003f 003b0039 00f8 00f8 0300 0700 0f00 bf00 fb00f300 e300 43e5 05e2 0085 0781 0180 028007e5 05e7";
		//Opcode Test
		private static string testProgram3 = "1208 a465 dab4 00ee 00e0 6832 6b1a a4b1d8b4 683a a4b5 d8b4 6802 6906 6a0b 6b01652a 662b a475 d8b4 a4ad d9b4 a465 362ba461 dab4 6b06 a479 d8b4 a4ad d9b4 a461452a a465 dab4 6b0b a47d d8b4 a4ad d9b4a461 5560 a465 dab4 6b10 a485 d8b4 a4add9b4 a461 76ff 462a a465 dab4 7b05 a48dd8b4 a4ad d9b4 a461 9560 a465 dab4 7b05a46d d8b4 a4ad d9b4 a465 128e a461 dab46812 6916 6a1b 6b01 a471 d8b4 a4ad d9b42202 7b05 a469 d8b4 a4a1 d9b4 a465 dab47b05 a489 d8b4 a469 d9b4 a461 652a 67008750 472a a465 dab4 7b05 a489 d8b4 a46dd9b4 a461 660b 672a 8761 472b a465 dab47b05 a489 d8b4 a471 d9b4 a461 6678 671f8762 4718 a465 dab4 7b05 a489 d8b4 a475d9b4 a461 6678 671f 8763 4767 a465 dab46822 6926 6a2b 6b01 a489 d8b4 a479 d9b4a461 668c 678c 8764 4718 a465 dab4 7b05a489 d8b4 a47d d9b4 a461 668c 6778 876547ec a465 dab4 7b05 a489 d8b4 a485 d9b4a461 6678 678c 8767 47ec a465 dab4 7b05a489 d8b4 a481 d9b4 a461 660f 8666 4607a465 dab4 7b05 a489 d8b4 a4a1 d9b4 a46166e0 866e 46c0 a465 dab4 7b05 a4a5 d8b4a481 d9b4 a45e f165 a465 30aa a461 3155a461 dab4 6832 6936 6a3b 6b01 a4a5 d8b4a47d d9b4 a45e 6000 6130 f155 a45e f0658100 a45f f065 a465 3030 a461 3100 a461dab4 7b05 a4a5 d8b4 a475 d9b4 a45e 6689f633 f265 a465 3001 a461 3103 a461 3207a461 dab4 7b05 a4a5 d8b4 a4a1 d9b4 a4616604 f61e dab4 7b05 a4a9 d8b4 a4ad d9b4a465 66ff 760a 3609 a461 8666 3604 a46166ff 600a 8604 3609 a461 8666 3604 a46166ff 866e 8666 367f a461 8666 866e 367ea461 6605 76f6 36fb a461 6605 8605 36fba461 6605 8067 30fb a461 dab4 145c aa550000 a040 a000 a0c0 80e0 a0a0 e0c0 4040e0e0 20c0 e0e0 6020 e0a0 e020 20e0 c020c060 80e0 e0e0 2040 40e0 e0a0 e0e0 e020c040 a0e0 a0c0 e0a0 e0e0 8080 e0c0 a0a0c0e0 c080 e0e0 80c0 8000 a0a0 40a0 40a0a00a aea2 4238 2828 b8";
		//Flags Test
		private static string testProgram4 = "12a0 6000 e0a1 1204 7001 4010 00ee 1204fc65 2276 4100 00ee 8010 2276 4200 00ee8020 2276 4300 00ee 8030 2276 4400 00ee8040 2276 4500 00ee 8050 2276 4600 00ee8060 2276 4700 00ee 8070 2276 4800 00ee8080 2276 4900 00ee 8090 2276 4a00 00ee80a0 2276 4b00 00ee 80b0 2276 4c00 00ee80c0 2276 00ee a53f f01e dde4 7d04 00eea543 8ed0 8eee 8eee fe1e dab4 7a05 00eea540 92c0 a53d 7b01 dab3 7a04 7bff 00ee00e0 6a32 6b1b a5f1 dab4 6a3a a5f5 dab46d00 6e00 a5df 2210 6a16 6b00 610f 6d012280 630f 6f14 83f1 6f00 6232 8211 8ef06c3f 2290 82e0 6c00 2290 8230 6c1f 22907a05 6d02 2280 630f 6f14 83f2 6f00 62328212 8ef0 6c02 2290 82e0 6c00 2290 82306c04 2290 7b05 6a00 6d03 2280 630f 6f1483f3 6f00 6232 8213 8ef0 6c3d 2290 82e06c00 2290 8230 6c1b 2290 7a05 6d04 22806f14 8f14 84f0 630f 6f14 83f4 6faa 62328214 8ef0 6c41 2290 82e0 6c00 2290 82306c23 2290 8240 6c00 2290 7a01 6d05 22806f14 8f15 84f0 6314 6f0f 83f5 6faa 62328215 8ef0 6c23 2290 82e0 6c01 2290 82306c05 2290 8240 6c01 2290 7b05 6a00 6d062280 6f3c 8ff6 83f0 6faa 623c 8226 8ef06c1e 2290 82e0 6c00 2290 8230 6c00 22907a05 6d07 2280 6f0a 8f17 84f0 630f 6f1483f7 6faa 620f 6132 8217 8ef0 6c23 229082e0 6c01 2290 8230 6c05 2290 8240 6c012290 7a01 6d0e 2280 6f32 8ffe 83f0 6faa6232 822e 8ef0 6c64 2290 82e0 6c00 22908230 6c00 2290 6d00 6e10 a5e5 2210 6a166b10 6164 6d04 2280 6fc8 8f14 84f0 63646fc8 83f4 6faa 62c8 8214 8ef0 6c2c 229082e0 6c01 2290 8230 6c2c 2290 8240 6c012290 7a01 6d05 2280 6f5f 8f15 84f0 635f6f64 83f5 6faa 625f 8215 8ef0 6cfb 229082e0 6c00 2290 8230 6cfb 2290 8240 6c002290 7b05 6a00 6d06 2280 6f3d 8ff6 83f06faa 623d 8226 8ef0 6c1e 2290 82e0 6c012290 8230 6c01 2290 7a05 6d07 2280 6f698f17 84f0 6369 6f64 83f7 6faa 6269 82178ef0 6cfb 2290 82e0 6c00 2290 8230 6cfb2290 8240 6c00 2290 7a01 6d0e 2280 6fbc8ffe 83f0 6faa 62bc 822e 8ef0 6c78 229082e0 6c01 2290 8230 6c01 2290 6d00 6e1ba5eb 2210 6a16 6b1b 6d0f 2280 7aff 6d0e2280 a52c 6110 f11e 60aa f055 a53c f0658200 6caa 2290 a52c 6f10 ff1e 6055 f055a53c f065 8200 6c55 2290 152a 0000 00000000 0000 0000 0000 0000 0000 00a0 c080a040 a0e0 a0a0 e0c0 4040 e0e0 20c0 e0e06020 e0a0 e020 20e0 c020 c0e0 80e0 e0e02020 20e0 e0a0 e0e0 e020 e040 a0e0 a0c0e0a0 e0e0 8080 e0c0 a0a0 c0e0 c080 e0e080c0 8060 80a0 60a0 e0a0 a0e0 4040 e0602020 c0a0 c0a0 a080 8080 e0e0 e0a0 a0c0a0a0 a0e0 a0a0 e0c0 a0c0 8040 a0e0 60c0a0c0 a060 c020 c0e0 4040 40a0 a0a0 60a0a0a0 40a0 a0e0 e0a0 40a0 a0a0 a040 40e06080 e000 0000 0000 e000 0000 0000 40482c68 688c 0034 2c70 708c 0064 7848 3c70000a aea2 4238 2828 b8";
		//Keypad Test
		private static string testProgram5 = "130c 6000 e0a1 1204 7001 4010 00ee 12046500 a222 f155 a282 f155 1222 4301 d0122202 0000 f51e f51e f51e f51e f165 6300f315 f407 3400 1244 a423 d012 640a f4156401 8343 640e e49e 1252 4500 1252 75ff121c 640f e49e 1260 9520 1260 7501 121c8650 640a e4a1 1280 6400 7201 7401 e49e1278 8640 76ff 1280 5420 126c 72ff 12322202 0000 f61e f61e f61e f61e 6402 f41ef165 6410 8041 a29a f155 0000 fc65 23024100 00ee 8010 2302 4200 00ee 8020 23024300 00ee 8030 2302 4400 00ee 8040 23024500 00ee 8050 2302 4600 00ee 8060 23024700 00ee 8070 2302 4800 00ee 8080 23024900 00ee 8090 2302 4a00 00ee 80a0 23024b00 00ee 80b0 2302 4c00 00ee 80c0 230200ee a427 f01e dde4 7d04 00ee 00e0 a1fff065 4001 1354 4002 1358 4003 13be 6d0a6e02 a4d3 229c 6d08 6e0a a4df 229c 6d086e0f a4eb 229c 6d08 6e14 a4f5 229c 6a326b1b a589 dab4 6a3a a58d dab4 60a4 61c76202 1210 619e 135a 61a1 60ee a39e f15500e0 a533 ff65 a412 ff55 6d12 6e03 a543229c 6d12 6e0a a54b 229c 6d12 6e11 a553229c 6d12 6e18 a55b 229c 6e00 2396 7e014e10 6e00 138c a412 fe1e f065 6201 eea16200 9020 13bc 80e0 800e a563 f01e f165a583 d016 a412 fe1e 8020 f055 00ee 00e06d06 6e0d a503 229c 6003 f015 f00a f1073100 13f2 e0a1 13f8 00e0 a425 601e 6109d013 6d10 6e11 a511 229c 2202 f00a 2202130c 6d0a a51a 13fc 6d08 a526 00e0 6e11229c a428 601e 6109 d013 2202 f00a 2202130c 0000 0000 0000 0000 0000 0000 00000000 00c0 c0a0 c080 a040 a0e0 a0a0 e0c04040 e0e0 20c0 e0e0 6020 e0a0 e020 20e0c020 c0e0 80e0 e0e0 2020 20e0 e0a0 e0e0e020 e040 a0e0 a0c0 e0a0 e0e0 8080 e0c0a0a0 c0e0 c080 e0e0 80c0 8060 80a0 60a0e0a0 a0e0 4040 e060 2020 c0a0 c0a0 a0808080 e0e0 e0a0 a0c0 a0a0 a0e0 a0a0 e0c0a0c0 8040 a0e0 60c0 a0c0 a060 c020 c0e04040 40a0 a0a0 60a0 a0a0 40a0 a0e0 e0a040a0 a0a0 a040 40e0 6080 e000 0000 0000e000 0000 0000 4004 0b03 5404 1003 58041503 be68 4c34 5494 6468 3464 383c 0008943c 8828 3c94 3864 8460 000c 943c 882c0894 7c68 0010 9440 8804 2c94 443c 78543c8c 0068 703c 7474 942c 608c 9454 3c8c002c 5858 9444 6464 3800 6064 7894 482c5878 4c60 4400 6064 7894 703c 583c 2c743c38 0000 0000 0000 0000 0000 0000 00000000 0008 940c 9410 9434 0014 9418 941c9438 0020 9424 9428 943c 002c 9404 94309440 0018 1710 0218 0220 0210 0918 09200910 1018 1020 1010 1720 1728 0228 09281028 17fe fefe fefe fe0a aea2 4238 2828b8";
		
		//https://github.com/Skosulor/c8int/blob/master/test/chip8_test.txt
		private static string testProgram6 = "60ff f015 6000 6900 6e00 6000 3001 30001392 7e01 6001 4001 4000 1392 7e01 61016200 5020 5010 1392 7e01 7002 70ff 3f001392 3002 1500 7e01 6bf0 8cb0 5cb0 13927e01 6a0f 6bf0 8ab1 3aff 1392 7e01 6a0f6bf1 8ab2 3a01 1392 7e01 6a0f 6bf1 8ab33afe 1392 7e01 6aff 6bf1 8ab4 3af0 13923f01 1392 7e01 6f00 6aff 6bf1 8ab5 3a0e1392 3f01 1392 7901 6e00 6f00 6a04 8a063a02 1300 3f00 1392 6a05 8a06 3a02 13003f01 1392 7e01 6af0 6bc3 8ab7 3ad3 13923f00 1392 6ac3 6bf0 8ab7 3a2d 1392 3f011392 7e01 6a04 8a0e 3a08 1392 3f00 13926a84 8a0e 3a08 1392 3f01 1392 7e01 6a006b00 9ab0 5ab0 1392 6a01 9ab0 1392 7e016004 b2fc 1392 1392 1392 1392 1392 13927e01 ca0f cbf0 8ab2 3a00 1392 caff cbff9ab0 1392 7e01 fa07 4aff 1392 7e01 6affa500 fa33 f265 3002 1392 3105 1392 32051392 7e01 6000 6101 6202 6303 6404 f45560ff 61ff 62ff 63ff 64ff f465 3000 13923404 1392 7e01 60fc a550 f055 a540 6010f01e f065 30fc 1392 6e00 7901 3e00 15003902 1392 6a19 6b10 a388 dab5 6a20 6b10a38d dab5 6f00 1386 6090 9090 6090 a0c0a090 00e0 f929 6510 6419 d455 6f00 fe296510 6420 d455 6f00 13a8 0305 1627 38495161 71e1 0115 1607 ed17 3365 1855 65191eea ebdd ed00 e000 ee9e a10a 1829 0a";


		private static string testProgram7 = "1225 5350 4143 4520 494e 5641 4445 52532076 302e 3920 4279 2044 6176 6964 2057494e 5445 5260 0061 0062 08a3 d3d0 187108f2 1e31 2012 2d70 0861 0030 4012 2d69056c 156e 0023 8760 0af0 15f0 0730 00124b23 877e 0112 4566 0068 1c69 006a 046b0a6c 046d 3c6e 0f00 e023 6b23 47fd 156004e0 9e12 7d23 6b38 0078 ff23 6b60 06e09e12 8b23 6b38 3978 0123 6b36 0012 9f6005e0 9e12 e966 0165 1b84 80a3 cfd4 51a3cfd4 5175 ff35 ff12 ad66 0012 e9d4 513f0112 e9d4 5166 0083 4073 0383 b562 f8832262 0833 0012 c923 7382 0643 0812 d3331012 d523 7382 0633 1812 dd23 7382 06432012 e733 2812 e923 733e 0013 0779 06491869 006a 046b 0a6c 047d f46e 0f00 e0234723 6bfd 1512 6ff7 0737 0012 6ffd 1523478b a43b 1213 1b7c 026a fc3b 0213 237c026a 0423 473c 1812 6f00 e0a4 d360 14610862 0fd0 1f70 08f2 1e30 2c13 33f0 0a00e0a6 f4fe 6512 25a3 b7f9 1e61 0823 5f810623 5f81 0623 5f81 0623 5f7b d000 ee80e080 1230 00db c67b 0c00 eea3 cf60 1cd80400 ee23 478e 2323 4760 05f0 18f0 15f00730 0013 7f00 ee6a 008d e06b 04e9 a11257a6 02fd 1ef0 6530 ff13 a56a 006b 046d016e 0113 8da5 00f0 1edb c67b 087d 017a013a 0713 8d00 ee3c 7eff ff99 997e ffff2424 e77e ff3c 3c7e db81 423c 7eff db10387c fe00 007f 003f 007f 0000 0001 01010303 0303 0000 3f20 2020 2020 2020 203f0808 ff00 00fe 00fc 00fe 0000 007e 42426262 6262 0000 ff00 0000 0000 0000 00ff0000 ff00 7d00 417d 057d 7d00 00c2 c2c6446c 2838 0000 ff00 0000 0000 0000 00ff0000 ff00 f710 14f7 f704 0400 007c 44fec2c2 c2c2 0000 ff00 0000 0000 0000 00ff0000 ff00 ef20 28e8 e82f 2f00 00f9 85c5c5c5 c5f9 0000 ff00 0000 0000 0000 00ff0000 ff00 be00 2030 20be be00 00f7 04e78585 84f4 0000 ff00 0000 0000 0000 00ff0000 ff00 007f 003f 007f 0000 00ef 28ef00e0 606f 0000 ff00 0000 0000 0000 00ff0000 ff00 00fe 00fc 00fe 0000 00c0 00c0c0c0 c0c0 0000 fc04 0404 0404 0404 04fc1010 fff9 81b9 8b9a 9afa 00fa 8a9a 9a9b99f8 e625 25f4 3434 3400 1714 3437 3626c7df 5050 5cd8 d8df 00df 111f 121b 19d97c44 fe86 8686 fc84 fe82 82fe fe80 c0c0c0fe fc82 c2c2 c2fc fe80 f8c0 c0fe fe80f0c0 c0c0 fe80 be86 86fe 8686 fe86 86861010 1010 1010 1818 1848 4878 9c90 b0c0b09c 8080 c0c0 c0fe ee92 9286 8686 fe828686 8686 7c82 8686 867c fe82 fec0 c0c07c82 c2ca c47a fe86 fe90 9c84 fec0 fe0202fe fe10 3030 3030 8282 c2c2 c2fe 828282ee 3810 8686 9692 92ee 8244 3838 44828282 fe30 3030 fe02 1ef0 80fe 0000 00000606 0000 0060 60c0 0000 0000 0000 18181818 0018 7cc6 0c18 0018 0000 fefe 0000fe82 8686 86fe 0808 0818 1818 fe02 fec0c0fe fe02 1e06 06fe 84c4 c4fe 0404 fe80fe06 06fe c0c0 c0fe 82fe fe02 0206 06067c44 fe86 86fe fe82 fe06 0606 44fe 4444fe44 a8a8 a8a8 a8a8 a86c 5a00 0c18 a8304e7e 0012 1866 6ca8 5a66 5424 6600 48481812 a806 90a8 1200 7e30 12a8 8430 4e721866 a8a8 a8a8 a8a8 9054 78a8 4878 6c72a812 186c 7266 5490 a872 2a18 a830 4e7e0012 1866 6ca8 7254 a85a 6618 7e18 4e72a872 2a18 3066 a830 4e7e 006c 3054 4e9ca8a8 a8a8 a8a8 a848 547e 18a8 9054 7866a86c 2a30 5aa8 8430 722a a8d8 a800 4e12a8e4 a2a8 004e 12a8 6c2a 5454 72a8 8430722a a8de 9ca8 722a 18a8 0c54 485a 78721866 a872 1842 426c a872 2a00 72a8 722a18a8 304e 7e00 1218 666c a830 4e0c 6618006c 18a8 722a 1830 66a8 1e54 660c 189ca824 5454 12a8 4278 0c3c a8ae a8a8 a8a8a8a8 a8ff 0000 0000 0000 0000 0000 00000000 00";


		//NOTE(Simon): Alternative palette: #312517 #BE9B75
		private static readonly Color foregroundColor = new Color(111, 77, 61, 255);
		private static readonly Color backgroundColor = new Color(203, 152, 103, 255);

		private static byte[] keyboard = new byte[16];

		private const int FPS = 60;
		private const int KHz = 1;

		public static void Main(string[] args)
		{
			var emulator = new Emulator();
			emulator.LoadProgram(ProgramFromString(testProgram3));

			Raylib.InitWindow(800, 600, "Hello Raylib!");
			Raylib.SetTargetFPS(FPS);

			var target = Raylib.LoadRenderTexture(64, 32);
			Raylib.SetTextureFilter(target.texture, TextureFilter.TEXTURE_FILTER_POINT);

			float scale = Math.Min(Raylib.GetScreenWidth() / 64f, Raylib.GetScreenHeight() / 32f);

			int cyclesPerFrame = (int)(KHz * 1e3 / 60);

			while (!Raylib.WindowShouldClose())
			{
				for (int i = 0; i < cyclesPerFrame; i++)
				{
					UpdateInput();
					emulator.Tick(keyboard, Raylib.GetTime());
				}

				Raylib.BeginTextureMode(target);
				{
					Raylib.ClearBackground(backgroundColor);
					for (int i = 0; i < 32; i++)
					{
						for (int j = 0; j < 64; j++)
						{
							if (emulator.display[i * 64 + j] > 0)
							{
								Raylib.DrawRectangle(j, i, 1, 1, foregroundColor);
							}
						}
					}
				}
				Raylib.EndTextureMode();

				Raylib.BeginDrawing();
				{
					Raylib.ClearBackground(Color.BLACK);

					var sourceRect = new Rectangle(0, 0, target.texture.width, -target.texture.height);
					var destRect = new Rectangle(Raylib.GetScreenWidth() - (64 * scale) * .5f, Raylib.GetScreenHeight() - (32 * scale) * .5f, 64 * scale, 32 * scale);

					Raylib.DrawTexturePro(
						target.texture, 
						sourceRect,
						destRect,
						new Vector2(Raylib.GetScreenWidth() / 2f, Raylib.GetScreenHeight() / 2f), 
						0, 
						Color.WHITE);

				}
				Raylib.EndDrawing();
			}

			Raylib.CloseWindow();
		}

		private static byte[] ProgramFromString(string program)
		{
			program = program.Replace(" ", "");

			if (program.Length % 2 != 0)
			{
				throw new ArgumentException("The program cannot have an odd number of digits");
			}

			byte[] data = new byte[program.Length / 2];
			for (int index = 0; index < data.Length; index++)
			{
				string byteValue = program.Substring(index * 2, 2);
				data[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
			}

			return data;
		}

		private static void UpdateInput()
		{
			Array.Clear(keyboard);

			keyboard[0x1] = (byte)(Raylib.IsKeyDown(KeyboardKey.KEY_ONE) ? 1 : 0);
			keyboard[0x2] = (byte)(Raylib.IsKeyDown(KeyboardKey.KEY_TWO) ? 1 : 0);
			keyboard[0x3] = (byte)(Raylib.IsKeyDown(KeyboardKey.KEY_THREE) ? 1 : 0);
			keyboard[0xC] = (byte)(Raylib.IsKeyDown(KeyboardKey.KEY_FOUR) ? 1 : 0);
			keyboard[0x4] = (byte)(Raylib.IsKeyDown(KeyboardKey.KEY_Q) ? 1 : 0);
			keyboard[0x5] = (byte)(Raylib.IsKeyDown(KeyboardKey.KEY_W) ? 1 : 0);
			keyboard[0x6] = (byte)(Raylib.IsKeyDown(KeyboardKey.KEY_E) ? 1 : 0);
			keyboard[0xD] = (byte)(Raylib.IsKeyDown(KeyboardKey.KEY_R) ? 1 : 0);
			keyboard[0x7] = (byte)(Raylib.IsKeyDown(KeyboardKey.KEY_A) ? 1 : 0);
			keyboard[0x8] = (byte)(Raylib.IsKeyDown(KeyboardKey.KEY_S) ? 1 : 0);
			keyboard[0x9] = (byte)(Raylib.IsKeyDown(KeyboardKey.KEY_D) ? 1 : 0);
			keyboard[0xE] = (byte)(Raylib.IsKeyDown(KeyboardKey.KEY_F) ? 1 : 0);
			keyboard[0xA] = (byte)(Raylib.IsKeyDown(KeyboardKey.KEY_Z) ? 1 : 0);
			keyboard[0x0] = (byte)(Raylib.IsKeyDown(KeyboardKey.KEY_X) ? 1 : 0);
			keyboard[0xB] = (byte)(Raylib.IsKeyDown(KeyboardKey.KEY_C) ? 1 : 0);
			keyboard[0xF] = (byte)(Raylib.IsKeyDown(KeyboardKey.KEY_V) ? 1 : 0);
		}
	}

	public class Emulator
	{
		private byte[] memory = new byte[4096];
		public byte[] display = new byte[64 * 32];

		private ushort PC;
		private Stack<ushort> stack = new Stack<ushort>(32);
		private byte[] registers = new byte[16];
		//NOTE(Simon): Also called address register
		private ushort indexRegister; 

		//NOTE(Simon): Timers count down at 60Hz
		private byte delayTimer;
		private byte soundTimer;
		private double timeOfLastTick;

		//NOTE(Simon): Memory is 4k, but programs should start at 0x200, and not occupy the last 352 bytes
		private const int MAX_PROGRAM_LENGTH = 4096 - 0x200 - 352;
		private const int FONT_MEMORY_OFFSET = 0x50;

		private readonly byte[] defaultFont = {
			0xF0, 0x90, 0x90, 0x90, 0xF0, // 0
			0x20, 0x60, 0x20, 0x20, 0x70, // 1
			0xF0, 0x10, 0xF0, 0x80, 0xF0, // 2
			0xF0, 0x10, 0xF0, 0x10, 0xF0, // 3
			0x90, 0x90, 0xF0, 0x10, 0x10, // 4
			0xF0, 0x80, 0xF0, 0x10, 0xF0, // 5
			0xF0, 0x80, 0xF0, 0x90, 0xF0, // 6
			0xF0, 0x10, 0x20, 0x40, 0x40, // 7
			0xF0, 0x90, 0xF0, 0x90, 0xF0, // 8
			0xF0, 0x90, 0xF0, 0x10, 0xF0, // 9
			0xF0, 0x90, 0xF0, 0x90, 0x90, // A
			0xE0, 0x90, 0xE0, 0x90, 0xE0, // B
			0xF0, 0x80, 0x80, 0x80, 0xF0, // C
			0xE0, 0x90, 0x90, 0x90, 0xE0, // D
			0xF0, 0x80, 0xF0, 0x80, 0xF0, // E
			0xF0, 0x80, 0xF0, 0x80, 0x80  // F
		};

		public void LoadProgram(byte[] data)
		{
			if (data.Length > MAX_PROGRAM_LENGTH)
			{
				throw new Exception($"Program too long for memory. Maximum length is {MAX_PROGRAM_LENGTH}b, while this program is {data.Length}b");
			}

			Array.Copy(data, 0, memory, 0x200, data.Length);
			LoadDefaultFont();
			PC = 0x200;
		}

		public void Tick(byte[] keyboard, double time)
		{
			double timerInterval = 1 / 60.0;
			if (time > timeOfLastTick + timerInterval)
			{
				double elapsed = time - timeOfLastTick;
				delayTimer -= (byte)(elapsed / timerInterval);
				soundTimer -= (byte)(elapsed / timerInterval);

				Console.WriteLine(delayTimer);

				timeOfLastTick = time;
			}

			ushort instruction = (ushort)(memory[PC] << 8 | memory[PC + 1]);
			PC += 2;

			ushort address = (ushort)(instruction & 0x0FFF);
			byte regX = (byte)((instruction & 0x0F00) >> 8);
			byte regY = (byte)((instruction & 0x00F0) >> 4);
			byte value = (byte)(instruction & 0x0FF);

			switch (instruction & 0xF000)
			{
				case 0x0000:
				{
					switch (instruction)
					{
						case 0x00E0:
						{
							//NOTE(Simon): Clear screen
							Array.Clear(display);
							break;
						}
						case 0x00EE:
						{
							//NOTE(Simon): Return from subroutine
							if (!stack.TryPop(out PC))
							{
								throw new Exception("Stack is empty");
							}

							break;
						}
						default:
						{
							goto unsupported_instruction;
						}
					}

					break;
				}
				case 0x1000:
				{
					//NOTE(Simon): Jump to address
					PC = address;
					break;
				}
				case 0x2000:
				{
					//NOTE(Simon): Execute subroutine starting at address
					stack.Push(PC);
					PC = address;
					break;
				}
				case 0x3000:
				{
					//NOTE(Simon): Skip the following instruction if the value of register equals value
					if (registers[regX] == value)
					{
						PC += 2;
					}

					break;
				}
				case 0x4000:
				{
					//NOTE(Simon): Skip the following instruction if the value of register is not equal to value
					if (registers[regX] != value)
					{
						PC += 2;
					}

					break;
				}
				case 0x5000:
				{
					//NOTE(Simon):Skip the following instruction if the value of register X is equal to the value of register Y
					if (registers[regX] == registers[regY])
					{
						PC += 2;
					}
					break;
				}
				case 0x6000:
				{
					//NOTE(Simon): Store value in register
					registers[regX] = value;
					break;
				}
				case 0x7000:
				{
					//NOTE(Simon): Add value to register
					registers[regX] += value;
					break;
				}
				case 0x8000:
				{
					switch (instruction & 0x000F)
					{
						case 0x0:
						{
							//NOTE(Simon): Store the value of register Y in register X
							registers[regX] = registers[regY];
							break;
						}
						case 0x1:
						{
							//NOTE(Simon): Set register X to (register X OR register Y)
							registers[regX] = (byte)(registers[regX] | registers[regY]);
							break;
						}
						case 0x2:
						{
							//NOTE(Simon): Set register X to (register X AND register Y)
							registers[regX] = (byte)(registers[regX] & registers[regY]);
							break;
						}
						case 0x3:
						{
							//NOTE(Simon): Set register X to (register X XOR register Y)
							registers[regX] = (byte)(registers[regX] ^ registers[regY]);
							break;
						}
						case 0x4:
						{
							//NOTE(Simon): Add the value of register Y to register X
							//NOTE(Simon): Set register F to 1 if a carry occurs, to 0 if a carry does not occur
							int result = registers[regX] + registers[regY];
							registers[regX] = (byte)result;
							registers[0xF] = (byte)(result > byte.MaxValue ? 1 : 0);
							break;
						}
						case 0x5:
						{
							//NOTE(Simon): Subtract the value of register Y from register X
							//NOTE(Simon): Set register F to 1 if a borrow does not occur, to 0 if a borrow occurs
							byte borrow = (byte)(registers[regX] > registers[regY] ? 1 : 0);
							registers[regX] = (byte)(registers[regX] - registers[regY]);
							registers[0xF] = borrow;
							break;
						}
						case 0x6:
						{
							//TODO(Simon): Ambiguous instruction, make configurable
							//NOTE(Simon): Store the value of register Y shifted right one bit in register X
							//NOTE(Simon): Set register F to the least significant bit prior to the shift
							byte lsb = (byte)(registers[regX] & 0x01);
							registers[regX] = (byte)(registers[regY] >> 1);
							registers[0xF] = lsb;
							break;
						}
						case 0x7:
						{
							//NOTE(Simon): Set register X to register Y minus register X
							//NOTE(Simon): Set register F to 1 if a borrow does not occur, to 0 if a borrow occurs
							byte borrow = (byte)(registers[regY] > registers[regX] ? 1 : 0);
							registers[regX] = (byte)(registers[regY] - registers[regX]);
							registers[0xF] = borrow;
							break;
						}
						case 0xE:
						{
							//TODO(Simon): Ambiguous instruction, make configurable
							//NOTE(Simon): Store the value of register Y shifted left one bit in register X
							//NOTE(Simon): Set register F to the most significant bit prior to the shift
							byte msb = (byte)((registers[regY] & 0x80) >> 7);
							registers[regX] = (byte)(registers[regY] << 1);
							registers[0xF] = msb;
							break;
						}
						default:
						{
							goto unsupported_instruction;
						}
					}

					break;
				}
				case 0x9000:
				{
					//NOTE(Simon):Skip the following instruction if the value of register X is not equal to the value of register Y
					if (registers[regX] != registers[regY])
					{
						PC += 2;
					}
					break;
				}
				case 0xA000:
				{
					//NOTE(Simon): Store address in register I
					indexRegister = address;
					break;
				}
				case 0xB000:
				{
					//TODO(Simon): Ambiguous instruction, make configurable.
					//NOTE(Simon): Jump to address NNN + V0
					PC = (ushort)(address + registers[0x0]);
					break;
				}
				case 0xC000:
				{
					//NOTE(Simon): Set VX to a random number with a mask of NN
					byte rand = (byte)(Random.Shared.NextSingle() * byte.MaxValue);
					byte result = (byte)(rand & value);
					registers[regX] = result;
					break;
				}
				case 0xD000:
				{
					//NOTE(Simon): Draw a sprite at position VX, VY with N bytes of sprite data starting at the address stored in I
					//NOTE(Simon): Set VF to 1 if any set pixels are changed to unset, and 0 otherwise
					int x = (byte)(registers[regX] % 64);
					int y = (byte)(registers[regY] % 32);
					int rows = (byte)(instruction & 0xF);
					registers[0xF] = 0;
					ushort spriteLoc = indexRegister;

					for (int i = 0; i < rows; i++)
					{
						int realY = y + i;
						if (realY >= 32)
						{
							break;
						}

						byte spriteRow = memory[spriteLoc + i];

						for (int j = 0; j < 8; j++)
						{
							int realX = x + j;
							if (realX >= 64)
							{
								break;
							}

							//NOTE(Simon): Extract bit at pos 7 - j (i.e. left to right)
							byte pixel = (byte)((spriteRow >> 7 - j) & 1);

							int displayIndex = realY * 64 + realX;
							byte before = display[displayIndex];
							display[displayIndex] = (byte)(display[displayIndex] ^ pixel);

							//NOTE(Simon): Set VF to 1 if any set pixels are changed to unset, and 0 otherwise. The logic is equivalent to "A OR (B AND NOT C)"
							registers[0xF] = (byte)(registers[0xF] | (before & ~display[displayIndex]));
						}
					}

					break;
				}
				case 0xE000:
				{
					if ((instruction & 0xFF) == 0x9E)
					{
						//NOTE(Simon): Skip the following instruction if the key corresponding to the hex value currently stored in register VX is pressed
						if (keyboard[registers[regX]] != 0)
						{
							PC += 2;
						}
					}
					else if ((instruction & 0xFF) == 0xA1)
					{
						//NOTE(Simon): Skip the following instruction if the key corresponding to the hex value currently stored in register VX is not pressed
						if (keyboard[registers[regX]] == 0)
						{
							PC += 2;
						}
					}
					else
					{
						goto unsupported_instruction;
					}

					break;
				}
				case 0xF000:
				{
					switch (instruction & 0xFF)
					{
						case 0x07:
						{
							//NOTE(Simon): Store the current value of the delay timer in register VX
							registers[regX] = delayTimer;
							break;
						}
						case 0x0A:
						{
							//NOTE(Simon):  Wait for a keypress and store the result in register VX
							int key = -1;
							for (int i = 0; i < keyboard.Length; i++)
							{
								if (keyboard[i] > 0)
								{
									key = i;
									break;
								}
							}

							if (key > -1)
							{
								registers[regX] = (byte)key;
							}
							else
							{
								//NOTE(Simon): This is supposed to be a blocking wait. We get the same behaviour by decrementing the PC here, thus never moving on until a key is pressed.
								PC -= 2;
							}

							break;
						}
						case 0x15:
						{
							//NOTE(Simon): Set the delay timer to the value of register VX
							delayTimer = registers[regX];
							break;
						}
						case 0x18:
						{
							//NOTE(Simon): Set the sound timer to the value of register VX
							soundTimer = registers[regX];
							break;
						}
						case 0x1E:
						{
							//NOTE(Simon): Add the value stored in register VX to register I
							indexRegister += registers[regX];
							break;
						}
						case 0x29:
						{
							//NOTE(Simon): Set I to the memory address of the sprite data corresponding to the hexadecimal digit stored in register VX
							byte digit = registers[regX];
							indexRegister = (ushort)(FONT_MEMORY_OFFSET + digit * 5);
							break;
						}
						case 0x33:
						{
							//NOTE(Simon): Store the binary - coded decimal equivalent of the value stored in register VX at addresses I, I + 1, and I + 2
							byte val = registers[regX];
							byte digit1 = (byte)(val / 100);
							val = (byte)(val - digit1 * 100);

							byte digit2 = (byte)(val / 10);
							val = (byte)(val - digit2 * 10);

							byte digit3 = val;

							memory[indexRegister + 0] = digit1;
							memory[indexRegister + 1] = digit2;
							memory[indexRegister + 2] = digit3;

							break;
						}
						case 0x55:
						{
							//TODO(Simon): Ambiguous instruction, make configurable
							//NOTE(Simon): Store the values of registers V0 to VX inclusive in memory starting at address I
							for (int i = 0; i <= regX; i++)
							{
								memory[indexRegister + i] = registers[i];
							}

							break;
						}
						case 0x65:
						{
							//TODO(Simon): Ambiguous instruction, make configurable
							//NOTE(Simon): Fill registers V0 to VX inclusive with the values stored in memory starting at address I
							for (int i = 0; i <= regX; i++)
							{
								registers[i] = memory[indexRegister + i];
							}
							break;
						}
						default:
						{
							goto unsupported_instruction;
						}
					}

					break;
				}
				default:
				{
					goto unsupported_instruction;
				}
			}

			return;

unsupported_instruction:
			throw new Exception($"Unsupported instruction \"{instruction}\"");
		}

		private void LoadDefaultFont()
		{
			Array.Copy(defaultFont, 0, memory, FONT_MEMORY_OFFSET, defaultFont.Length);
		}
	}
}

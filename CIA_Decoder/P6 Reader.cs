using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace CIA_Decoder
{
    class P6_Reader
    {
        public Bitmap LoadPPM(string filename, int imgWidth, int imgLength,List<string> comments)
        {
            FileStream Inputfile = new FileStream(filename, FileMode.Open);

            char curByte = ' ';
            //goes through the headder
            for (int index = 0; index < 3 + comments.Count; index++)
            {
                curByte = (char)Inputfile.ReadByte();
                //read in all the bytes untill it reaches a new line
                while (curByte != '\n')
                {
                    curByte = (char)Inputfile.ReadByte();
                }
            }
            //help

            Bitmap P6IMG = new Bitmap(imgWidth, imgLength);

            //loop through the x and y by grabbing three lines of RGB values for each pixel
            for (int totalY = 0; totalY < imgLength; totalY++)
            {
                for (int totalX = 0; totalX < imgWidth; totalX++)
                {
                    int redVal = Inputfile.ReadByte();
                    int grnVal = Inputfile.ReadByte();
                    int bluVal = Inputfile.ReadByte();
                    Color colCurrent = Color.FromArgb(redVal, grnVal, bluVal);
                    //add the pixels that are appropriate for beung used to encode
                    P6IMG.SetPixel(totalX, totalY, colCurrent);
                }
            }
            //set P3IMG to the user selected picture box
            Inputfile.Close();
            return P6IMG;
            

        }
    }
}

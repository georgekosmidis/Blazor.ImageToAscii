using System;
using System.Collections.Generic;
using System.Text;

namespace Image2Text.Core.ByteTransformations
{
    public class BytesConverter
    {
        public BytesConverter()
        {

        }

        public string[] Convert(byte[][] values, string ramp)
        {
            if (values == null)
            {
                return null;
            }

            int numberOfColumns = values[0].Length;
            int numberOfRows = values.Length;

            string[] result = new string[numberOfRows];

            for (int y = 0; y < numberOfRows; y++)
            {
                StringBuilder builder = new StringBuilder();

                for (int x = 0; x < numberOfColumns; x++)
                {
                    builder.Append(
                        ValueCharacter(values[y][x], ramp)
                    );
                }

                result[y] = builder.ToString();
            }

            return result;
        }

        public static string ValueCharacter(byte b, string ramp)
        {
            float length = (float)(ramp.Length - 1);

            return ramp[(int)((((float)b / 255f) * length) + 0.5f)].ToString();

        }
    }
}

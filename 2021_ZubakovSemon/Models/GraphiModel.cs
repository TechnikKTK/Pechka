using MathLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2021_ZubakovSemon.Models
{
    public class GraphicModel
    {
        public string AixXLabel { get; set; }
        public string DataSet { get; set; }
        public string AdditionalData { get; set; }

        public double Right { get; set; }
        public double Left { get; set; }

        public GraphicModel(MathLib.StenkaMathLib stenka)
        {
            string[] data = getCoord(stenka);
           
            AixXLabel = data[0];
            DataSet = data[1];
            AdditionalData = data[2];
        }

        private string[] getCoord(StenkaMathLib stenka)
        {
            Left = -0.5;
            string data = string.Format("[(x: {0:0.00},y: {1:0.00}),",Left+0.2, stenka.Tgas);
            string layerData = "{label: 's0', type: 'line', borderColor: 'red', borderWidth: 4," + "data:[{ x: 0, y: 0},{ x: 0,y:" + GetStringDouble(stenka.Tgas + 10) + "}]}";
            data += string.Format("(x: 0,y: {0:0}),", GetStringDouble(stenka.T1Stenk));

            switch (stenka.Layers)
            {
                case 2:
                    data += string.Format("(x: {0:0.00},y: {1:0.00}),", stenka.S1, stenka.T2border);
                    layerData += ",{label: 's1', type: 'line',borderColor: 'blue', borderWidth: 4," + "data:[{ x: "
+ GetStringDouble(stenka.S1) + ", y:0},{ x: "
+ GetStringDouble(stenka.S1) + ",y:"
+ GetStringDouble(stenka.Tgas + 10) + "}]}";

                    data += string.Format("(x: {0:0.00},y: {1:0.00}),", stenka.S1 + stenka.S2, stenka.TOutBorder);
                    layerData += ",{label: 's2', type: 'line',borderColor: 'green', borderWidth: 4," + "data:[{ x: "
+ GetStringDouble(stenka.S1 + stenka.S2) + ", y:0},{ x: "
+ GetStringDouble(stenka.S1 + stenka.S2) + ",y:"
+ GetStringDouble(stenka.Tgas + 10) + "}]}";

                    data += string.Format("(x: {0:0.00},y: {1:0.00})]", stenka.S1 + stenka.S2  + 0.3, stenka.TEnvironment);
                    Right = (stenka.S1 + stenka.S2 + 0.5);
                    break;
                case 3:
                    data += string.Format("(x: {0:0.00},y: {1:0.00}),", stenka.S1, stenka.T2border);
                    layerData += ",{label: 's1', type: 'line',borderColor: 'blue', borderWidth: 4," + "data:[{ x: "
+ GetStringDouble(stenka.S1) + ", y:0},{ x: "
+ GetStringDouble(stenka.S1) + ",y:"
+ GetStringDouble(stenka.Tgas + 10) + "}]}";

                    data += string.Format("(x: {0:0.00},y: {1:0.00}),", stenka.S1 + stenka.S2, stenka.T3border);
                    layerData += ",{label: 's2', type: 'line',borderColor: 'green', borderWidth: 4," + "data:[{ x: "
+ GetStringDouble(stenka.S1 + stenka.S2) + ", y:0},{ x: "
+ GetStringDouble(stenka.S1 + stenka.S2) + ",y:"
+ GetStringDouble(stenka.Tgas + 10) + "}]}";

                    data += string.Format("(x: {0:0.00},y: {1:0.00}),", stenka.S1 + stenka.S2 + stenka.S3, stenka.TOutBorder);
                    layerData += ",{label: 's3', type: 'line',borderColor: 'brown', borderWidth: 4," + "data:[{ x: "
+ GetStringDouble(stenka.S1 + stenka.S2 + stenka.S3) + ", y:0},{ x: "
+ GetStringDouble(stenka.S1 + stenka.S2 + stenka.S3) + ",y:"
+ GetStringDouble(stenka.Tgas + 10) + "}]}";

                    data += string.Format("(x: {0:0.00},y: {1:0.00})]", stenka.S1 + stenka.S2 + stenka.S3  + 0.3, stenka.TEnvironment);
                    Right = (stenka.S1 + stenka.S2 + stenka.S3 + 0.5);
                    break;
                case 4:
                    data += string.Format("(x: {0:0.00},y: {1:0.00}),", stenka.S1, stenka.T2border);
                    layerData += ",{label: 's1', type: 'line',borderColor: 'blue', borderWidth: 4," + "data:[{ x: "
+ GetStringDouble(stenka.S1) + ", y:0},{ x: "
+ GetStringDouble(stenka.S1) + ",y:"
+ GetStringDouble(stenka.Tgas + 10) + "}]}";
                    
                    data += string.Format("(x: {0:0.00},y: {1:0.00}),", stenka.S1 + stenka.S2, stenka.T3border);
                    layerData += ",{label: 's2', type: 'line',borderColor: 'green', borderWidth: 4," + "data:[{ x: "
+ GetStringDouble(stenka.S1 + stenka.S2) + ", y:0},{ x: "
+ GetStringDouble(stenka.S1 + stenka.S2) + ",y:"
+ GetStringDouble(stenka.Tgas + 10) + "}]}";
                      
                    data += string.Format("(x: {0:0.00},y: {1:0.00}),", stenka.S1 + stenka.S2 + stenka.S3, stenka.T4border);
                    layerData += ",{label: 's3', type: 'line',borderColor: 'brown', borderWidth: 4," + "data:[{ x: "
+ GetStringDouble(stenka.S1 + stenka.S2 + stenka.S3) + ", y:0},{ x: "
+ GetStringDouble(stenka.S1 + stenka.S2 + stenka.S3) + ",y:"
+ GetStringDouble(stenka.Tgas + 10) + "}]}";
                     
                    data += string.Format("(x: {0:0.00},y: {1:0.00}),", stenka.S1 + stenka.S2 + stenka.S3+ stenka.S4, stenka.TOutBorder);
                    layerData += ",{label: 's4', type: 'line',borderColor: 'gray', borderWidth: 4," + "data:[{ x: "
+ GetStringDouble(stenka.S1 + stenka.S2 + stenka.S3 + stenka.S4) + ", y:0},{ x: "
+ GetStringDouble(stenka.S1 + stenka.S2 + stenka.S3 + stenka.S4) + ",y:"
+ GetStringDouble(stenka.Tgas + 10) + "}]}";

                    data += string.Format("(x: {0:0.00},y: {1:0.00})]", stenka.S1 + stenka.S2 + stenka.S3 + stenka.S4 + 0.3, stenka.TEnvironment);
                    Right = (stenka.S1 + stenka.S2 + stenka.S3 + stenka.S4 + 0.5);
                    break;
            }
        data = data.Replace('(', '{').Replace(')', '}').Replace(',','.').Replace(".y",",y").Replace("}.{","},{");

            string label = "[\"Газ\",";
            for (int i = 0; i < stenka.Layers; i++)
            {
                label += string.Format("\"s{0}\",", i + 1);
            }
            label += "\"Улица\"]";

            return new string[] { label, data, layerData };
        }

        private string GetStringDouble(double val)
        {
            return val.ToString().Replace(',', '.');
        }
    }
}

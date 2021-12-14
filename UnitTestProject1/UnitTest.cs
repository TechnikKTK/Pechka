using MathLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest
    {
        private string fileName = "Macros.xlsm";
        Excel.Application objExcel = null;
        Excel.Workbook WorkBook = null;

        private object oMissing = System.Reflection.Missing.Value;

        private StenkaMathLib _stenka = new StenkaMathLib();

        /// <summary>
        /// Метод тестирования математической библиотеки
        /// </summary>
        [TestMethod]
        public void CalculationTest()
        {
            #region 1. Присвоить исходные данные 

            Console.WriteLine("--- Исходные данные");
            _stenka.S1 = 0.232;
            _stenka.S2 = 0.1;
            _stenka.S3 = 0.21;
            _stenka.S4 = 0.464;
            _stenka.TEnvironment = 5;
            _stenka.Tgas = 900;
            _stenka.A1 = 0.93;
            _stenka.A2 = 0.84;
            _stenka.A3 = 0.1;
            _stenka.A4 = 0.04;
            _stenka.B1 = 0.69;
            _stenka.B2 = 0.58;
            _stenka.B3 = 0.28;
            _stenka.B4 = 0.302;
            _stenka.KoefK = 2.4;
            _stenka.DegreeOfBlack = 0.5;
            _stenka.SumKoef = 16;
            _stenka.StefBol = 0.000000057;
            _stenka.T1Stenk = 886.658534797733;
            _stenka.T2border = 854.303741156368;
            _stenka.T3border = 838.264262231805;
            _stenka.T4border = 695.856883874014;
            _stenka.TOutBorder = 41.2256535984197;


            Console.WriteLine("Толщина 1 стенки: S1 = {0}", _stenka.S1.ToString());
            Console.WriteLine("Толщина 2 стенки: S2 = {0}", _stenka.S2.ToString());
            Console.WriteLine("Толщина 3 стенки: S3 = {0}", _stenka.S3.ToString());
            Console.WriteLine("Толщина 4 стенки: S4 = {0}", _stenka.S4.ToString());
            Console.WriteLine("Температура окружающей среды: TEnvironment = {0}", _stenka.TEnvironment.ToString());
            Console.WriteLine("Температура газа: TGasa = {0}", _stenka.Tgas.ToString());
            Console.WriteLine("Коэффициент для расчета теплопроводность 1 материала: A1 = {0}", _stenka.A1.ToString());
            Console.WriteLine("Коэффициент для расчета теплопроводность 2 материала: A2 = {0}", _stenka.A2.ToString());
            Console.WriteLine("Коэффициент для расчета теплопроводность 3 материала: A3 = {0}", _stenka.A3.ToString());
            Console.WriteLine("Коэффициент для расчета теплопроводность 4 материала: A4 = {0}", _stenka.A4.ToString());
            Console.WriteLine("Коэффициент для расчета теплопроводность 1 материала: B1 = {0}", _stenka.B1.ToString());
            Console.WriteLine("Коэффициент для расчета теплопроводность 2 материала: B2 = {0}", _stenka.B2.ToString());
            Console.WriteLine("Коэффициент для расчета теплопроводность 3 материала: B3 = {0}", _stenka.B3.ToString());
            Console.WriteLine("Коэффициент для расчета теплопроводность 4 материала: B4 = {0}", _stenka.B4.ToString());
            Console.WriteLine("Коэффициент, учитывающий положение поверхности К: K = {0}", _stenka.KoefK.ToString());
            Console.WriteLine("Степень черноты стенки: DegreeOfBlack = {0}", _stenka.DegreeOfBlack.ToString());
            Console.WriteLine("Суммарный коэффициент теплоотдачи aSum = {0}", _stenka.SumKoef.ToString());
            Console.WriteLine("Постоянная Стефана-Больцмана StefBol = {0}", _stenka.StefBol.ToString());
            Console.WriteLine("Температура 1 стенки: T1 = {0}", _stenka.T1Stenk.ToString());
            Console.WriteLine("Температура 2 стенки: T2 = {0}", _stenka.T2border.ToString());
            Console.WriteLine("Температура 3 стенки: T3 = {0}", _stenka.T3border.ToString());
            Console.WriteLine("Температура 4 стенки: T4 = {0}", _stenka.T4border.ToString());
            Console.WriteLine("Температура наружной стенки: To = {0}", _stenka.TOutBorder.ToString());

            #endregion 1. Присвоить исходные данные 

            #region 2. Передать исходные данные в Excel-файл, записать в соответствующие ячейки

            objExcel = new Excel.Application();
            WorkBook = objExcel.Workbooks.Open(
                        Directory.GetCurrentDirectory() + "\\" + fileName);
            Excel.Worksheet WorkSheetInputData = (Excel.Worksheet)WorkBook.Sheets["1 слой стенки"];

            // Cells[СТРОКА, СТОЛБЕЦ])     
            ((Excel.Range)WorkSheetInputData.Cells[1, 9]).Value2 = _stenka.A1;
            ((Excel.Range)WorkSheetInputData.Cells[1, 11]).Value2 = _stenka.B1;
            ((Excel.Range)WorkSheetInputData.Cells[2, 9]).Value2 = _stenka.A2;
            ((Excel.Range)WorkSheetInputData.Cells[2, 11]).Value2 = _stenka.B2;
            ((Excel.Range)WorkSheetInputData.Cells[3, 9]).Value2 = _stenka.A3;
            ((Excel.Range)WorkSheetInputData.Cells[3, 11]).Value2 = _stenka.B3;
            ((Excel.Range)WorkSheetInputData.Cells[4, 9]).Value2 = _stenka.A4;
            ((Excel.Range)WorkSheetInputData.Cells[4, 11]).Value2 = _stenka.B4;
            ((Excel.Range)WorkSheetInputData.Cells[4, 2]).Value2 = _stenka.S1;
            ((Excel.Range)WorkSheetInputData.Cells[5, 2]).Value2 = _stenka.S2;
            ((Excel.Range)WorkSheetInputData.Cells[6, 2]).Value2 = _stenka.S3;
            ((Excel.Range)WorkSheetInputData.Cells[7, 2]).Value2 = _stenka.S4;
            ((Excel.Range)WorkSheetInputData.Cells[8, 2]).Value2 = _stenka.TEnvironment;
            ((Excel.Range)WorkSheetInputData.Cells[9, 2]).Value2 = _stenka.Tgas;
            ((Excel.Range)WorkSheetInputData.Cells[14, 2]).Value2 = _stenka.KoefK;  
            ((Excel.Range)WorkSheetInputData.Cells[15, 2]).Value2 = _stenka.DegreeOfBlack;
            ((Excel.Range)WorkSheetInputData.Cells[16, 2]).Value2 = _stenka.SumKoef;
            ((Excel.Range)WorkSheetInputData.Cells[17, 2]).Value2 = _stenka.StefBol;
            ((Excel.Range)WorkSheetInputData.Cells[19, 2]).Value2 = _stenka.T1Stenk;
            ((Excel.Range)WorkSheetInputData.Cells[20, 2]).Value2 = _stenka.T2border;
            ((Excel.Range)WorkSheetInputData.Cells[21, 2]).Value2 = _stenka.T3border;
            ((Excel.Range)WorkSheetInputData.Cells[22, 2]).Value2 = _stenka.T4border;
            ((Excel.Range)WorkSheetInputData.Cells[23, 2]).Value2 = _stenka.TOutBorder;







            #endregion 2. Передать исходные данные в Excel-файл, записать в соответствующие ячейки

            #region 3. Прочитать из ячейки Excel-файла значение расчетных величин

            Excel.Worksheet WorkSheetOutputData = (Excel.Worksheet)WorkBook.Sheets["1 слой стенки"];

            // Cells[СТРОКА, СТОЛБЕЦ]
            double _Get_ATeplo1 = double.Parse(((Excel.Range)WorkSheetOutputData.Cells[10, 2]).Value.ToString());
            double _Get_ATeplo2 = double.Parse(((Excel.Range)WorkSheetOutputData.Cells[11, 2]).Value.ToString());
            double _Get_ATeplo3 = double.Parse(((Excel.Range)WorkSheetOutputData.Cells[12, 2]).Value.ToString());
            double _Get_ATeplo4 = double.Parse(((Excel.Range)WorkSheetOutputData.Cells[13, 2]).Value.ToString());
            double _Get_Q_gas = double.Parse(((Excel.Range)WorkSheetOutputData.Cells[5, 6]).Value.ToString());
            double _Get_Q1Stenk = double.Parse(((Excel.Range)WorkSheetOutputData.Cells[6, 6]).Value.ToString());
            double _Get_Q2Stenk = double.Parse(((Excel.Range)WorkSheetOutputData.Cells[7, 6]).Value.ToString());
            double _Get_Q3Stenk = double.Parse(((Excel.Range)WorkSheetOutputData.Cells[8, 6]).Value.ToString());
            double _Get_Q4Stenk = double.Parse(((Excel.Range)WorkSheetOutputData.Cells[9, 6]).Value.ToString());
            double _Get_A_otdachi = double.Parse(((Excel.Range)WorkSheetOutputData.Cells[18, 2]).Value.ToString());
            double _Get_Qenvironment = double.Parse(((Excel.Range)WorkSheetOutputData.Cells[10, 6]).Value.ToString());





            Console.WriteLine("                      ");
            Console.WriteLine("--- Результаты расчета");

            #endregion 3. Прочитать из ячейки Excel-файла значение расчетных величин

            #region  4. Сравнить значения из Excel и из библиотеки с заданной точностью

            Assert.AreEqual(_Get_ATeplo1, Math.Round(_stenka.ATeplo1(), 2), 0.001);
            System.Diagnostics.Debug.WriteLine(" Коэффициент теплопроводности первой стенки, Вт/(м*К): ATeplo1(): expected =" +
                        _Get_ATeplo1 + "; actual=" + Math.Round(_stenka.ATeplo1(), 2));
            Assert.AreEqual(_Get_ATeplo2, Math.Round(_stenka.ATeplo2(), 2), 0.001);
            System.Diagnostics.Debug.WriteLine(" Коэффициент теплопроводности второй стенки, Вт/(м*К): ATeplo2(): expected =" +
                        _Get_ATeplo2 + "; actual=" + Math.Round(_stenka.ATeplo2(), 2));
            Assert.AreEqual(_Get_ATeplo3, Math.Round(_stenka.ATeplo3(), 3), 0.001);
            System.Diagnostics.Debug.WriteLine(" Коэффициент теплопроводности третьей стенки, Вт/(м*К): ATeplo3(): expected =" +
                        _Get_ATeplo3 + "; actual=" + Math.Round(_stenka.ATeplo3(), 3));
            Assert.AreEqual(_Get_ATeplo4, Math.Round(_stenka.ATeplo4(), 3), 0.001);
            System.Diagnostics.Debug.WriteLine(" Коэффициент теплопроводности четвертой стенки, Вт/(м*К): ATeplo4(): expected =" +
                        _Get_ATeplo4 + "; actual=" + Math.Round(_stenka.ATeplo4(), 3));
            Assert.AreEqual(_Get_A_otdachi, Math.Round(_stenka.A_otdachi(), 3), 0.001);
            System.Diagnostics.Debug.WriteLine(" Коэффициент теплоотдачи от внешней стенки в окр. среду а (Вт/м2 *К): A_otdachi(): expected =" +
                        _Get_A_otdachi + "; actual=" + Math.Round(_stenka.A_otdachi(), 3));
            Assert.AreEqual(_Get_Q_gas, Math.Round(_stenka.Q_gas(), 3), 0.001);
            System.Diagnostics.Debug.WriteLine(" Тепловой поток от газа к стенке, Вт: Q_gas(): expected =" +
                        _Get_Q_gas + "; actual=" + Math.Round(_stenka.Q_gas(), 3));
            Assert.AreEqual(_Get_Q2Stenk, Math.Round(_stenka.Q2Stenk(), 2), 0.001);
            System.Diagnostics.Debug.WriteLine(" Тепловой поток во второй стенке, Вт: Q2Stenk(): expected =" +
                        _Get_Q2Stenk + "; actual=" + Math.Round(_stenka.Q2Stenk(), 2));
            Assert.AreEqual(_Get_Q3Stenk, Math.Round(_stenka.Q3Stenk(), 2), 0.001);
            System.Diagnostics.Debug.WriteLine(" Тепловой поток в третьей стенке, Вт: Q3Stenk(): expected =" +
                        _Get_Q3Stenk + "; actual=" + Math.Round(_stenka.Q3Stenk(), 2));
            Assert.AreEqual(_Get_Q4Stenk, Math.Round(_stenka.Q4Stenk(), 2), 0.001);
            System.Diagnostics.Debug.WriteLine(" Тепловой поток в четвертой стенке, Вт: Q4Stenk(): expected =" +
                        _Get_Q4Stenk + "; actual=" + Math.Round(_stenka.Q4Stenk(), 2));
            Assert.AreEqual(_Get_Qenvironment, Math.Round(_stenka.Qenvironment(), 2), 0.1);
            System.Diagnostics.Debug.WriteLine(" Тепловой поток в четвертой стенке, Вт: Qenvironment(): expected =" +
                        _Get_Qenvironment + "; actual=" + Math.Round(_stenka.Qenvironment(), 2));




            #endregion  4. Сравнить значения из Excel и из библиотеки с заданной точностью

            if (WorkBook != null) WorkBook.Close(false, null, null);
            if (objExcel != null) objExcel.Quit();
        }


    }
}

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib
{
    public class StenkaMathLib
    {

        /// <summary>
        /// Постоянная Стефана-Больцмана
        /// </summary> 
        public double StefBol = 0.000000057;

        /// <summary>
        /// Суммарный коэффициент теплоотдачи, альфа, Вт/(м2 *К) ??? - TO DO: пока принять константу
        /// </summary> 
        public int SumKoef = 16;

        /// <summary>
        /// Коэффициент, учитывающий положение поверхности стенки
        /// </summary> 
        public double KoefK = 2.4;

        #region --- Исходные данные


        private double _Layers;
        public double Layers
        {
            get { return _Layers; }
            set { _Layers = value; }

        }


        private double _S1;
        /// <summary>
        /// Количество слоёв стенки
        /// </summary> 
        /// 
        public double S1
        {
            get { return _S1; }
            set { _S1 = value; }
        }


        private double _S2;
        /// <summary>
        /// Толщина 2-й стенки S2, м
        /// </summary> 
        public double S2
        {
            get { return _S2; }
            set { _S2 = value; }
        }


        private double _S3;
        /// <summary>
        /// Толщина 3-й стенки S3, м
        /// </summary> 
        public double S3
        {
            get { return _S3; }
            set { _S3 = value; }
        }

        private double _S4;
        /// <summary>
        /// Толщина 4-й стенки S4, м
        /// </summary> 
        public double S4
        {
            get { return _S4; }
            set { _S4 = value; }
        }

        private double _TEnvironment;
        /// <summary>
        ///  Температура окружающей среды, °С
        /// </summary> 
        public double TEnvironment
        {
            get { return Math.Round(_TEnvironment,3); }
            set { _TEnvironment = value; }
        }

        private double _Tgas;
        /// <summary>
        ///  Температура газа, °С
        /// </summary> 
        public double Tgas
        {
            get { return Math.Round(_Tgas,3); }
            set { _Tgas = value; }
        }

        private double _DegreeOfBlack;
        /// <summary>
        /// Степень черноты, доли ед.
        /// </summary> 
        public double DegreeOfBlack
        {
            get { return _DegreeOfBlack; }
            set { _DegreeOfBlack = value; }
        }


        private double _A1;
        /// <summary>
        /// Коэффициент A1 для расчета теплопроводности 1-го материала
        /// </summary>
        public double A1
        {
            get { return _A1; }
            set { _A1 = value; }
        }

        private double _A2;
        /// <summary>
        /// Коэффициент A2 для расчета теплопроводности 2-го материала
        /// </summary>
        public double A2
        {
            get { return _A2; }
            set { _A2 = value; }
        }
        private double _A3;
        /// <summary>
        /// Коэффициент A3 для расчета теплопроводности 3-го материала
        /// </summary>
        public double A3
        {
            get { return _A3; }
            set { _A3 = value; }
        }
        private double _A4;
        /// <summary>
        /// Коэффициент A4 для расчета теплопроводности 4-го материала
        /// </summary>
        public double A4
        {
            get { return _A4; }
            set { _A4 = value; }
        }

        private double _B1;
        /// <summary>
        /// Коэффициент B1 для расчета теплопроводности 1-го материала
        /// </summary>
        public double B1
        {
            get { return _B1; }
            set { _B1 = value; }
        }
        private double _B2;
        /// <summary>
        /// Коэффициент B2 для расчета теплопроводности 2-го материала
        /// </summary>
        public double B2
        {
            get { return _B2; }
            set { _B2 = value; }
        }
        private double _B3;
        /// <summary>
        /// Коэффициент B3 для расчета теплопроводности 3-го материала
        /// </summary>
        public double B3
        {
            get { return _B3; }
            set { _B3 = value; }
        }
        private double _B4;
        /// <summary>
        /// Коэффициент B4 для расчета теплопроводности 4-го материала
        /// </summary>
        public double B4
        {
            get { return _B4; }
            set { _B4 = value; }
        }

        private double _T1Stenk;
        /// <summary>
        /// Температура внутренней стенки T1, °С
        /// </summary>
        public double T1Stenk
        {
            get { return Math.Round(_T1Stenk,3); }
            set { _T1Stenk = value; }
        }

        private double _T2border;
        /// <summary>
        /// Температура на границе поверхностей стенки T2, °С
        /// </summary>
        public double T2border
        {
            get { return Math.Round(_T2border,3); }
            set { _T2border = value; }
        }

        private double _T3border;
        /// <summary>
        ///  Температура границы поверхностей стенки T3, °С
        /// </summary>
        public double T3border
        {
            get { return Math.Round(_T3border,3); }
            set { _T3border = value; }
        }

        private double _T4border;
        /// <summary>
        ///  Температура границы поверхностей стенки T4, °С
        /// </summary>
        public double T4border
        {
            get { return Math.Round(_T4border,3); }
            set { _T4border = value; }
        }


        private double _TOutBorder;
        /// <summary>
        ///  Температура наружной стенки, °С
        /// </summary>
        public double TOutBorder
        {
            get { return Math.Round(_TOutBorder,3); }
            set { _TOutBorder = value; }
        }

        #endregion --- Исходные данные

        #region --- Расчетные показатели

        /// <summary>
        ///  Коэффициент теплоотдачи от внешней стенки в окружающую среду, альфа, Вт/(м2*К)
        /// </summary>
        public double A_otdachi()
        {
            double _A_otdachi = (KoefK * (Math.Pow(_TOutBorder - _TEnvironment, 0.25)) + (StefBol * ((Math.Pow(_TOutBorder, 4)) - (Math.Pow(_TEnvironment, 4)))) / (_TEnvironment + _TOutBorder));
            return Math.Round(_A_otdachi,3);
        }


        /// <summary>
        /// Коэффициент теплопроводности первой стенки, Вт/(м*К)
        /// </summary>  
        public double ATeplo1()
        {
            double _ATeplo1 = _A1 + _B1 * 0.001 * ((_T1Stenk + _T2border) / 2d);
            return Math.Round(_ATeplo1,3);
        }
        /// <summary>
        /// Коэффициент теплопроводности второй стенки, Вт/(м*К)
        /// </summary>  
        public double ATeplo2()
        {
            double _ATeplo2 = _A2 + _B2 * 0.001 * ((_T2border + _T3border) / 2d);
            return Math.Round(_ATeplo2,3);
        }
        /// <summary>
        /// Коэффициент теплопроводности третьей стенки, Вт/(м*К)
        /// </summary>  
        public double ATeplo3()
        {
            double _ATeplo3 = _A3 + _B3 * 0.001 * ((_T3border + _T4border) / 2);
            return Math.Round(_ATeplo3,3);
        }
        /// <summary>
        /// Коэффициент теплопроводности четвертой стенки, Вт/(м*К)
        /// </summary>  
        public double ATeplo4()
        {
            double _ATeplo4 = _A4 + _B4 * 0.001 * ((_T4border + _TOutBorder) / 2);
            return Math.Round(_ATeplo4,3);
        }
        /// <summary>
        /// Плотность теплового потока от газа к стенке, Вт/м2


        /// <summary>
        /// Плотность теплового потока от газа к стенке, Вт/м2
        /// </summary>  
        /// 

        public double Q_gas()
        {
            double _Qgas = SumKoef * (_Tgas - _T1Stenk);

            return Math.Round(_Qgas,3);
        }
        /// <summary>
        /// Плотность теплового потока в первой стенке, Вт/м2
        /// </summary> 
        public double Q1Stenk()
        {

            double _Q1Stenk = (_T1Stenk - _T2border) / (_S1 / ATeplo1());


            return Math.Round(_Q1Stenk,3);

        }



        /// <summary>
        /// Плотность теплового потока во второй стенке, Вт/м2
        /// </summary> 
        public double Q2Stenk()
        {
            double _Q2Stenk = 0;

            if (Layers == 2)
            {
                _T3border = 0;
                _T4border = 0;
                S4 = 0;

                _Q2Stenk = (_T2border - _TOutBorder) / (S2 / ATeplo2());
            }
            else
            {
                _Q2Stenk = (_T2border - _T3border) / (S2 / ATeplo2());
            }

            return Math.Round(_Q2Stenk,3);

        }
        /// <summary>
        /// Плотность теплового потока в третьей стенке, Вт/м2
        /// </summary> 
        public double Q3Stenk()
        {
            double _Q3Stenk = 0;
            if (Layers == 3)
            {
                _T4border = 0;
                S4 = 0;
                 _Q3Stenk = (_T3border - _TOutBorder) / (_S3 / ATeplo3());


            }
            else
            {
                _Q3Stenk = (_T3border - _T4border) / (_S3 / ATeplo3());
            }
            return Math.Round(_Q3Stenk,3);
        }
        /// <summary>
        /// Плотность теплового потока в четвертой стенке, Вт/м2
        /// </summary> 
        public double Q4Stenk()
        {
           
            double _Q4Stenk = (_T4border - TOutBorder) / (S4 / ATeplo4());
            
            return Math.Round(_Q4Stenk,3);
        }

        /// <summary>
        /// Плотность теплового потока от четвертой в окружающую среду, Вт/м2
        /// </summary> 
        public double Qenvironment()
        {
            double _Qenvironment = (A_otdachi() * (_TOutBorder - _TEnvironment));
            


            return Math.Round(_Qenvironment, 3);
            
        }
     
        public void Equeals()
        {
            if (Layers == 4)
            {

                while (true)
                {
                    double _Qgas = Q_gas();
                    double _Q1Stenk = Q1Stenk();
                    double _Q2Stenk = Q2Stenk();
                    double _Q3Stenk = Q3Stenk();
                    double _Q4Stenk = Q4Stenk();
                    double _Qenvironment = Qenvironment();

                    double q12 = _Qgas - _Q1Stenk;
                    double q23 = _Q1Stenk - _Q2Stenk;
                    double q34 = _Q2Stenk - _Q3Stenk;
                    double q45 = _Q3Stenk - _Q4Stenk;
                    double q56 = _Q4Stenk - _Qenvironment;

                    double max = Math.Max(

                        Math.Max(

                            Math.Max(Math.Abs(q12), Math.Abs(q23)),

                            Math.Max(Math.Abs(q34), Math.Abs(q45))),

                        Math.Max(Math.Abs(q45), Math.Abs(q56)));

                    if (max == Math.Abs(q12))
                    {
                        if (q12 < 0) _T1Stenk = _T1Stenk - 0.01;
                        else _T1Stenk = _T1Stenk + 0.01;
                        Q_gas();
                    }
                    else if (max == Math.Abs(q23))
                    {
                        if (q23 < 0) _T2border = _T2border - 0.01;
                        else _T2border = _T2border + 0.01;
                        Q1Stenk();
                    }
                    else if (max == Math.Abs(q34))
                    {
                        if (q34 < 0) _T3border = _T3border - 0.01;
                        else _T3border = _T3border + 0.01;
                        Q2Stenk();
                    }
                    else if (max == Math.Abs(q45))
                    {
                        if (q45 < 0) _T4border = _T4border - 0.01;
                        else _T4border = _T4border + 0.01;
                        Q3Stenk();
                    }
                    else if (max == Math.Abs(q56))
                    {
                        if (q56 < 0) TOutBorder = TOutBorder - 0.01;
                        else TOutBorder = TOutBorder + 0.01;
                        Q4Stenk();
                    }


                    if (Math.Abs(q12) < 1 && Math.Abs(q23) < 1 && Math.Abs(q34) < 1 && Math.Abs(q45) < 1 && Math.Abs(q56) < 1) break;

                }
            }
            if (Layers == 2) {
                while (true)
                {
                   
                    double _Qgas = Q_gas();
                    double _Q1Stenk = Q1Stenk();
                    double _Q2Stenk = Q2Stenk();
                    double _Qenvironment = Qenvironment();

                    double q12 = _Qgas - _Q1Stenk;
                    double q23 = _Q1Stenk - _Q2Stenk;
                    double q34 = _Q2Stenk - _Qenvironment;

                    double max = 

                         
                               Math.Max(

                            Math.Max(Math.Abs(q12), Math.Abs(q23)),

                            Math.Max(Math.Abs(q23), Math.Abs(q34)));

                       

                    if (max == Math.Abs(q12))
                    {
                        if (q12 < 0) _T1Stenk = _T1Stenk - 0.01;
                        else _T1Stenk = _T1Stenk + 0.01;
                        Q_gas();
                    }
                    else if (max == Math.Abs(q23))
                    {
                        if (q23 < 0) _T2border = _T2border - 0.01;
                        else _T2border = _T2border + 0.01;
                        Q1Stenk();
                    }
                    else if (max == Math.Abs(q34))
                    {
                        if (q34 < 0) TOutBorder = TOutBorder - 0.01;
                        else TOutBorder = TOutBorder + 0.01;
                        Q2Stenk();
                    }
                    
                    


                    if (Math.Abs(q12) < 1 && Math.Abs(q23) < 1 && Math.Abs(q34) < 1) break;
                    Qenvironment();
                }

            }
            if (Layers == 3)
            {
                while (true)
                {
                    double _Qgas = Q_gas();
                    double _Q1Stenk = Q1Stenk();
                    double _Q2Stenk = Q2Stenk();
                    double _Q3Stenk = Q3Stenk();
                
                    double _Qenvironment = Qenvironment();

                    double q12 = _Qgas - _Q1Stenk;
                    double q23 = _Q1Stenk - _Q2Stenk;
                    double q34 = _Q2Stenk - _Q3Stenk;
                    double q45 = _Q3Stenk - _Qenvironment;


                    double max = 

                        Math.Max(

                            Math.Max(Math.Abs(q12), Math.Abs(q23)),

                            Math.Max(Math.Abs(q34), Math.Abs(q45)));

                     

                    if (max == Math.Abs(q12))
                    {
                        if (q12 < 0) _T1Stenk = _T1Stenk - 0.01;
                        else _T1Stenk = _T1Stenk + 0.01;
                        Q_gas();
                    }
                    else if (max == Math.Abs(q23))
                    {
                        if (q23 < 0) _T2border = _T2border - 0.01;
                        else _T2border = _T2border + 0.01;
                        Q1Stenk();
                    }
                    else if (max == Math.Abs(q34))
                    {
                        if (q34 < 0) _T3border = _T3border - 0.01;
                        else _T3border = _T3border + 0.01;
                        Q2Stenk();
                    }
                    else if (max == Math.Abs(q45))
                    {
                        if (q45 < 0) TOutBorder = TOutBorder - 0.01;
                        else TOutBorder = TOutBorder + 0.01;
                        Q3Stenk();
                    }
                   


                    if (Math.Abs(q12) < 1 && Math.Abs(q23) < 1 && Math.Abs(q34) < 1 && Math.Abs(q45) < 1 ) break;

                }

            }


        }


            #endregion --- Расчетные показатели

        }
   
}
 
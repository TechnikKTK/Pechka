using MathLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2021_ZubakovSemon.Models
{
    public class DataOutputModel
    {
        private StenkaMathLib _stenka = new StenkaMathLib();
        private DataInputModel _DataInput = new DataInputModel();

        public StenkaMathLib StenkaData { get { return _stenka; } }

        public DataOutputModel() { }

        public DataOutputModel(DataInputModel DataInput)
        {
            _DataInput = DataInput;

            #region --- Передать исходные данные в экземпляр библиотеки

            _stenka.Layers = _DataInput.Layers;
            _stenka.S1 = _DataInput.S1;
            _stenka.S2 = _DataInput.S2;
            _stenka.S3 = _DataInput.S3;
            _stenka.S4 = _DataInput.S4;
            _stenka.TEnvironment = _DataInput.TEnvironment;
            _stenka.Tgas = _DataInput.Tgas;
            _stenka.TOutBorder = _DataInput.TOutBorder;
            _stenka.A1 = _DataInput.A1;
            _stenka.A2 = _DataInput.A2;
            _stenka.A3 = _DataInput.A3;
            _stenka.A4 = _DataInput.A4;
            _stenka.B1 = _DataInput.B1;
            _stenka.B2 = _DataInput.B2;
            _stenka.B3 = _DataInput.B3;
            _stenka.B4 = _DataInput.B4;
            _stenka.T1Stenk = _DataInput.T1Stenk;
            _stenka.T2border = _DataInput.T2border;
            _stenka.T3border = _DataInput.T3border;
            _stenka.T4border = _DataInput.T4border;


            // TO DO: надо передать остальные исходные данные


            #endregion --- Передать исходные данные в экземпляр библиотеки
        }


        #region --- Получить расчетные показатели
        public double Layers
        {
            get { return _stenka.Layers; }
        }

        /// <summary>
        ///  Коэффициент теплоотдачи от внешней стенки в окружающую среду, альфа, Вт/(м2*К)
        /// </summary>         
        public double A_otdachi
        {
            get { return _stenka.A_otdachi(); }
        }
        /// <summary>
        /// Коэффициент теплопроводности первой стенки, Вт/(м*К)
        /// </summary>
        public double ATeplo1
        {
            get { return _stenka.ATeplo1(); }
        }
        /// <summary>
        /// Коэффициент теплопроводности второй стенки, Вт/(м*К)
        /// </summary>
        public double ATeplo2
        {
            get { return _stenka.ATeplo2(); }
        }
        /// <summary>
        /// Коэффициент теплопроводности третьей стенки, Вт/(м*К)
        /// </summary>
        public double ATeplo3
        {
            get { return _stenka.ATeplo3(); }
        }

        

        /// <summary>
        /// Коэффициент теплопроводности третьей стенки, Вт/(м*К)
        /// </summary>
        public double ATeplo4
        {
            get { return _stenka.ATeplo4(); }
        }
        /// <summary>
        /// Плотность теплового потока от газа к стенке
        /// </summary>
        public double Q_gas
        {
            get { return _stenka.Q_gas(); }
        }
        /// <summary>
        /// Плотность теплового потока в первой стенке, Вт/м2
        /// </summary> 
        public double Q1Stenk
        {
            get { return _stenka.Q1Stenk(); }
        }
        /// <summary>
        /// Плотность теплового потока во второй стенке, Вт/м2
        /// </summary> 
        public double Q2Stenk
        {
            get { return _stenka.Q2Stenk(); }
        }
        /// <summary>
        /// Плотность теплового потока в третьей стенке, Вт/м2
        /// </summary> 
        public double Q3Stenk
        {
            get { return _stenka.Q3Stenk(); }
        }
        /// <summary>
        /// Плотность теплового потока в четвертой стенке, Вт/м2
        /// </summary> 
        public double Q4Stenk
        {
            get { return _stenka.Q4Stenk(); }
        }
        /// <summary>
        /// Плотность теплового потока от четвертой в окружающую среду, Вт/м2
        /// </summary> 
        public double Qenvironment
        {
            get { return _stenka.Qenvironment(); }
        }

        public void Equeals()
        {
           _stenka.Equeals(); 
        }



        // TO DO: надо получить остальные расчетные показатели



        #endregion --- Получить расчетные показатели

    }
}

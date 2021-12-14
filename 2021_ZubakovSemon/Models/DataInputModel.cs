using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _2021_ZubakovSemon.Models
{
    public class DataInputModel
    {
        
        public double Layers { get; set; }
        /// <summary>
        /// Толщина 1-й стенки S1, м
        /// </summary> 

        [Required(ErrorMessage = "Не указана толщина первого слоя")]
        public double S1 { get; set; }

        /// <summary>
        /// Толщина 2-й стенки S1, м
        /// </summary> 
        public double S2 { get; set; }

        /// <summary>
        /// Толщина 3-й стенки S1, м
        /// </summary> 
        public double S3 { get; set; }

        /// <summary>
        /// Толщина 4-й стенки S1, м
        /// </summary> 
        public double S4 { get; set; }

        /// <summary>
        /// Температура окружающей среды, °С
        /// </summary> 
        public double TEnvironment { get; set; }

        /// <summary>
        /// Температура газа, °С
        /// </summary> 
        public double Tgas { get; set; }
        /// <summary>
        /// Коэффицициент для расчета теплопроводности 1-го материала
        /// </summary> 
        public double A1 { get; set; }
        /// <summary>
        /// Коэффицициент для расчета теплопроводности 2-го материала
        /// </summary> 
        public double A2 { get; set; }
        /// <summary>
        /// Коэффицициент для расчета теплопроводности 3-го материала
        /// </summary> 
        public double A3 { get; set; }
        /// <summary>
        /// Коэффицициент для расчета теплопроводности 4-го материала
        /// </summary> 
        public double A4 { get; set; }
        /// <summary>
        /// Коэффицициент для расчета теплопроводности 1-го материала
        /// </summary> 
        public double B1 { get; set; }
        /// <summary>
        /// Коэффицициент для расчета теплопроводности 2-го материала
        /// </summary> 
        public double B2 { get; set; }
        /// <summary>
        /// Коэффицициент для расчета теплопроводности 3-го материала
        /// </summary> 
        public double B3 { get; set; }
        /// <summary>
        /// Коэффицициент для расчета теплопроводности 4-го материала
        /// </summary> 
        public double B4 { get; set; }
        /// <summary>
        ///  Температура внутренней стенки T1,
        /// </summary> 
        public double T1Stenk { get; set; }
        /// <summary>
        ///   Температура на границе поверхностей стенки T2,
        /// </summary> 
        public double T2border { get; set; }
        /// <summary>
        ///  Температура границы поверхностей стенки T3, °С
        /// </summary>
        public double T3border { get; set; }
        /// <summary>
        ///  Температура границы поверхностей стенки T4, °С
        /// </summary>
        public double T4border { get; set; }

        /// <summary>
        /// Температура наружной стенки, °С
        /// </summary> 
        public double TOutBorder { get; set; }

    }
}

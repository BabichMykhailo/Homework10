using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern2
{
    class Program
    {
        static void Main(string[] args)
        {
            // содаем объект фармацевта 
            Pharmaceft baker = new Pharmaceft();
            // создаем билдер для анальгина
            MedicineBuilder builder = new AnalginBuilder();
            // создаем
            Medicine analgin = baker.MakeMedecine(builder);
            Console.WriteLine(analgin.ToString());
            // cоздаем билдер угля
            builder = new CoalBuilder();
            Medicine coal = baker.MakeMedecine(builder);
            Console.WriteLine(coal.ToString());

            Console.Read();
        }
    }
    // абстрактный класс строителя
    abstract class MedicineBuilder
    {
        public Medicine Medicine { get; private set; }
        public void CreateMedicine()
        {
            Medicine = new Medicine();
        }
        public abstract void SetActive();
        public abstract void SetPassive();
    }
    // пекарь
    class Pharmaceft
    {
        public Medicine MakeMedecine(MedicineBuilder medicineBuilder)
        {
            medicineBuilder.CreateMedicine();
            medicineBuilder.SetActive();
            medicineBuilder.SetPassive();
            return medicineBuilder.Medicine;
        }
    }
    // строитель для ржаного хлеба
    class AnalginBuilder : MedicineBuilder
    {
        public override void SetActive()
        {
            this.Medicine.Active = new Active { Name = "Уголь" };
        }


        public override void SetPassive()
        {
            // не используется
        }
    }
    // строитель для пшеничного хлеба
    class CoalBuilder : MedicineBuilder
    {
        public override void SetActive()
        {
            this.Medicine.Active = new Active { Name = "Метамизол" };
        }

        

        public override void SetPassive()
        {
            this.Medicine.Passive = new Passive { Name = "кальция стеарат" };
        }
    }

    //мука
    class Active
    {
        // вид активного вещества
        public string Name { get; set; }
    }

 
    // пищевые добавки
    class Passive
    {
        public string Name { get; set; }
    }

    class Medicine
    {
        // Активные вещества 
        public Active Active { get; set; }
        
        // пищевые добавки
        public Passive Passive { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (Active != null)
                sb.Append(Active.Name + "\n");
            if (Passive != null)
                sb.Append("Пасивное вещество: " + Passive.Name + " \n");
            return sb.ToString();
        }
    }
}

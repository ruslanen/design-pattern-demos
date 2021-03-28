using DesignPatternDemos.AbstractFactory.Parts;

namespace DesignPatternDemos.AbstractFactory
{
    public abstract class Computer
    {
        protected ICpu Cpu;

        protected IVideoCard VideoCard;

        protected IRam Ram;
        
        protected abstract void Build(); 
        
        public virtual void InstallSoftware()
        {
            // Установить базовый набор софта
        }

        public virtual void Package()
        {
            // Упаковать в стандартную упаковку
        }
    }
}
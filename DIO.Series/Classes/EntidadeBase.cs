namespace DIO.Series 
{
    public abstract class EntidadeBase
    {
        public int Id { get; protected set; } //classe abstrata que contém o ID e todas as classes que herdarem dela obrigatporiamente consta o ID
    }
}
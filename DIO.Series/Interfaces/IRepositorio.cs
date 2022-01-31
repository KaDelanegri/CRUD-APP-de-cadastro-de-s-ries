using System.Collections.Generic;

namespace DIO.Series.Interfaces //defindo métodos obrigatórios para as classes que implementarem a interface
{
    public interface IRepositorio<T> //interface de repositório para armazenagem da lista de filmes, para ficar abstraído do código
    {
        //métodos que será obrigatório implementação:
         List<T> Lista(); //o tipo T é um tipo genérico
         T RetornaPorId(int id); //passa o ID e vai retornar o T
         void Insere(T entidade);
         void Exclui(int id);
         void Atualiza(int id, T entidade);
         int ProximoId();
    }
}
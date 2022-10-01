using System;
using System.Collections.Generic;

namespace Proj_ONTHEFLY_CS_SQL
{
    public class Passageiro
    {
        //Propriedades
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public char Sexo { get; set; }
        public DateTime UltimaCompra { get; set; }
        public DateTime DataCadastro { get; set; }
        public char Situacao { get; set; }

        //Metodos
        public Passageiro(string cPF, string nome, DateTime dataNascimento, char sexo, DateTime ultimaCompra, DateTime dataCadastro, char situacao)
        {
            CPF = cPF;
            Nome = nome;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            UltimaCompra = ultimaCompra;
            DataCadastro = dataCadastro;
            Situacao = situacao;
        }
        public Passageiro(string cPF, string nome, DateTime dataNascimento, char sexo)
        {
            CPF = cPF;
            Nome = nome;
            DataNascimento = dataNascimento;
            Sexo = sexo;
        }
        public Passageiro(string cPF, char situacao)
        {
            CPF = cPF;
            Situacao = situacao;
        }
        public override string ToString()
        {
            return $"CPF:\t\t\t{CPF.Substring(0, 3)}.{CPF.Substring(3, 3)}.{CPF.Substring(6, 3)}-{CPF.Substring(9, 2)}\n" +
                    $"Nome:\t\t\t{Nome}\n" +
                    $"Data de Nascimento:\t{DataNascimento:dd/MM/yyyy}\n" +
                    $"Sexo:\t\t\t{Sexo}\n" +
                    $"Ultima Compra:\t\t{UltimaCompra:dd/MM/yyyy}\n" +
                    $"Data Cadastro:\t\t{DataCadastro:dd/MM/yyyy}";
        }
        public static bool FindKey(List<Passageiro> listaDePassageiros, string cPF)
        {
            foreach (Passageiro passageiro in listaDePassageiros)
            {
                if (passageiro.CPF == cPF) return true;
            }
            return false;
        }
    }
}

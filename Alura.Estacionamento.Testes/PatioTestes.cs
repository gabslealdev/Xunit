using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Estacionamento.Testes;

public class PatioTestes
{
    public TipoVeiculo Automovel { get; private set; }

    [Fact]
    public void ValidaFaturamento()
    {
        //Arrange
        var estacionamento = new Patio();
        var carro = new Veiculo();
        carro.Proprietario = "Armando Goulart";
        carro.Tipo = Automovel;
        carro.Placa = "CNO-1500";
        estacionamento.RegistrarEntradaVeiculo(carro);
        //Act
        estacionamento.RegistrarSaidaVeiculo(carro.Placa);
        //Assert
        Assert.Equal(2, estacionamento.Faturado);
        
    }
}

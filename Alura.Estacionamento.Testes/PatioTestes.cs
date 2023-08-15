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
    [Theory]
    [InlineData("Clarice Bergamo", "PTF-2004", "vermelho", "gol")]
    [InlineData("Otavio Marcondes", "WSV-2456", "amarelo", "fusca")]
    [InlineData("Vicente Borges", "RDR-8731", "vinho", "s10")]
    
    public void TesteMultiploFaturamento(string proprietario, string placa, string cor, string modelo)
    {
        var estacionamento = new Patio();
        var carro = new Veiculo(proprietario);
        carro.Tipo = TipoVeiculo.Automovel;
        carro.Placa = placa;
        carro.Cor = cor;
        carro.Modelo = modelo;
        estacionamento.RegistrarEntradaVeiculo(carro);
        estacionamento.RegistrarSaidaVeiculo(placa);
        Assert.Equal(2, estacionamento.Faturado);
    }
    [Theory]
    [InlineData("Gabriel Leal", "SVN-4700", "Preto", "Fiesta")]
    public void ProcuraVeiculo(string proprietario, string placa, string cor, string modelo)
    {
        var estacionamento = new Patio();
        var carro = new Veiculo();
        carro.Proprietario = proprietario;
        carro.Placa = placa;
        carro.Cor = cor;
        carro.Modelo = modelo;
        estacionamento.RegistrarEntradaVeiculo(carro);

        var consultado = estacionamento.PesquisaVeiculo(placa);

        Assert.Equal(placa, consultado.Placa);
    }
    [Fact]
    public void AlterarDadosVeiculo()
    {
        Patio estacionamento = new Patio();
        Veiculo veiculo = new Veiculo();
        veiculo.Proprietario = "Pedro Coelho";
        veiculo.Placa = "AXL-1924";
        veiculo.Cor = "Prata";
        veiculo.Modelo = "Corsa";
        estacionamento.RegistrarEntradaVeiculo(veiculo);

        var veiculoTemp = new Veiculo();
        veiculoTemp.Proprietario = "";
        veiculoTemp.Placa = "AXL-1924";
        veiculoTemp.Cor = "Preto";
        veiculoTemp.Modelo = "Corsa";

        Veiculo veiculoAlterado = estacionamento.AlterarDadosVeiculo(veiculoTemp);

        Assert.Equal(veiculoAlterado.Cor, veiculo.Cor);
    }
}

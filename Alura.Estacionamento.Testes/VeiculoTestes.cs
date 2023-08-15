using Alura.Estacionamento;
using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System.ComponentModel.DataAnnotations;

namespace Alura.Estacionamento.Testes;
public class VeiculoTestes
{
    [Fact]
    public void TestaVeiculoAcelerar()
    {
        // Padrão AAA 
          
        // Arrange
        var veiculo = new Veiculo();
        // Act
        veiculo.Acelerar(10);
        // Assert
        Assert.Equal(100, veiculo.VelocidadeAtual);
    }
    [Fact]
    public void TestaVeiculoFrear()
    {
        var veiculo = new Veiculo();
        veiculo.Frear(10);
        Assert.Equal(-150, veiculo.VelocidadeAtual);
    }
    [Fact]
    public void DadosVeiculo()
    {
        var veiculo = new Veiculo();
        veiculo.Proprietario = "Alfredo Guimarães";
        veiculo.Tipo = TipoVeiculo.Automovel;
        veiculo.Modelo = "Honda Civic";
        veiculo.Placa = "ADA-8899";
        veiculo.Cor = "Prata";

        string dados = veiculo.ToString();

        Assert.Contains("veiculo",dados);
    }
}
# FinancialControl.Api

Sistema de Controle Financeiro desenvolvido em **.NET 8**. O projeto utiliza uma arquitetura organizada para facilitar a manutenção e escalabilidade, focando na gestão eficiente de fluxos de caixa.

## 🛠️ Tecnologias e Arquitetura
* **C# / .NET 8**: Linguagem e framework principal.
* **ASP.NET Core Web API**: Para a criação dos endpoints.
* **Arquitetura em Camadas**: 
    * `FinancialControl.Api`: Interface e Controllers.
    * `FinancialControl.Models`: Entidades e objetos de transferência (DTOs).
    * `FinancialControl.Services`: Lógica de negócio e regras da aplicação.

## ⚙️ Como executar
1. Certifique-se de ter o SDK do .NET instalado.
2. Clone este repositório.
3. No terminal, execute:
   ```bash
   dotnet restore
   dotnet run

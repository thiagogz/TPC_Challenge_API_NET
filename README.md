# LesSoft - A TPC Solution

## Sumário
- [Integrantes;](#integrantes)
- [Arquitetura da API;](#arquitetura-da-api)
- [Instruções para uso da aplicação;](#instruções-para-uso-da-aplicação)
- [Observações importantes.](#observações-importantes)

## Integrantes
- Beatriz Lucas - RM99104;
- Enzo Farias - RM98792;
- Ewerton Gonçalves - RM98571;
- Guilherme Tantulli - RM97890;
- Thiago Zupelli - RM99085.

## Arquitetura da API
### Monolítica vs Microserviços
A arquitetura monolítica é um estilo de design de software onde toda a aplicação é desenvolvida como uma única unidade coesa. Em vez de dividir a aplicação em vários serviços independentes, tudo está integrado em um único projeto.
Por outro lado, a arquitetura de microserviços é um estilo de design de software que estrutura uma aplicação como uma coleção de serviços independentes e autônomos. Em outras palavras, a aplicação é dividida em várias partes menores, cada uma com sua própria responsabilidade e que se comunica com outras partes por meio de APIs bem definidas.\
Vantagens da Arquitetura Monolítica:
- Simplicidade: A estrutura única facilita o desenvolvimento e a manutenção, já que todas as funcionalidades estão no mesmo lugar. Isso reduz a complexidade de integração e permite uma visão unificada da aplicação.
- Desempenho: Como todos os componentes da aplicação estão na mesma base de código e rodando no mesmo processo, a comunicação entre eles é mais rápida e eficiente, sem a sobrecarga das chamadas de rede.
- Desdobramento e Escalonamento: A construção e o despliegue são mais diretos e rápidos. Não é necessário lidar com múltiplos serviços e suas interações. O escalonamento da aplicação pode ser feito verticalmente, aumentando os recursos do servidor único.
- Menor Custo Inicial: O desenvolvimento de uma aplicação monolítica pode ser menos custoso inicialmente, pois evita a complexidade associada à implementação e manutenção de múltiplos serviços e suas interações.
- Facilidade de Testes: A abordagem monolítica facilita o teste de integração, pois todos os componentes estão juntos e interagem diretamente no mesmo ambiente.

Vantagens da Arquitetura de Microserviços:
- Resiliência: Falhas em um serviço não afetam diretamente outros serviços, aumentando a robustez e a capacidade de recuperação da aplicação como um todo.
- Desenvolvimento Descentralizado: Equipes diferentes podem trabalhar em microsserviços distintos simultaneamente, permitindo uma entrega mais ágil e flexível.
- Tecnologias Diversificadas: Permite o uso de diferentes tecnologias e linguagens de programação para diferentes serviços, otimização de acordo com as necessidades específicas de cada parte da aplicação.
- Manutenção e Atualizações: Atualizações e manutenções podem ser realizadas em um microsserviço sem a necessidade de impactar toda a aplicação, facilitando a implementação de novas funcionalidades e correções de bugs.

### Por que escolhemos a arquitetura monolítica?
Tendo isso em vista, nossa decisão foi de seguir com a arquitetura monolítica de acordo com os seguintes critérios:
- O projeto é relativamente pequeno e não requer a complexidade e a escalabilidade oferecidas pela arquitetura de microserviços;
- Apenas uma linguagem de programação e a conexão com um banco de dados são necessários para o desenvolvimento da aplicação;
- Com a arquitetura monolítica, podemos concentrar todo o desenvolvimento em uma única base de código, simplificando a gestão e a manutenção;
- A comunicação direta dentro de um único processo resulta em uma aplicação mais ágil e com menor latência;
- A estrutura unificada facilita o gerenciamento do projeto e a realização de testes, garantindo uma abordagem mais direta e integrada.
Assim, escolhemos a arquitetura monolítica para garantir um desenvolvimento mais eficiente e menos complexo, adequando-se melhor às necessidades e restrições do nosso projeto.


### Tecnologias utilizadas
- **`Linguagem de Programação`**: C#;
- **`Framework`**: .NET Core 8.0;
- **`Banco de Dados`**: Oracle Database;
- **`Design Pattern`**: Repository Pattern;

## Instruções para uso da aplicação

**Execução da Aplicação**:
    - Para iniciar a aplicação, você deve dar play com a configuração **`https`**. Isso pode ser feito diretamente dentro do seu Visual Studio (Ambiente de Desenvolvimento Integrado).

**Execução das requisições**:
    - Após inicializar a aplicação, uma página web será aberta no seu navegador padrão. Nela, você poderá visualizar a documentação da API, bem como realizar requisições para a mesma;
    - Para realizar a requisição desejada, basta clicar no endpoint desejado e, em seguida, no botão **`Try it out`**. Após isso, você poderá preencher os campos necessários para a requisição e, por fim, clicar no botão **`Execute`**.

## Observações importantes
Como as tabelas **`CreditCompra`** e **`PontosCompra`** são tabelas relacionais, elas não possuem Primary Keys. Dessa maneira, foi configurado para que a leitura delas seja feita a partir da combinação das duas chaves.\
Dito isso, os métodos **`POST`** e **`PUT`** dessas tabelas funcionam inserindo a relação delas e apagando as anteriores para substituir pela atualização solicitada, respectivamente.\
Dessa maneira, após utilizar o método **`PUT`**, é necessário fazer a requisição por ID atualizada, inserindo os dois novos IDs.

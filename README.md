# LesSoft - A TPC Solution

## Sum�rio
- [Integrantes;](#integrantes)
- [Arquitetura da API;](#arquitetura-da-api)
- [Instru��es para uso da aplica��o.](#instru��es-para-uso-da-aplica��o)

## Integrantes
- Beatriz Lucas - RM99104;
- Enzo Farias - RM98792;
- Ewerton Gon�alves - RM98571;
- Guilherme Tantulli - RM97890;
- Thiago Zupelli - RM99085.

## Arquitetura da API
### Monol�tica vs Microservi�os
A arquitetura monol�tica � um estilo de design de software onde toda a aplica��o � desenvolvida como uma �nica unidade coesa. Em vez de dividir a aplica��o em v�rios servi�os independentes, tudo est� integrado em um �nico projeto.
Por outro lado, a arquitetura de microservi�os � um estilo de design de software que estrutura uma aplica��o como uma cole��o de servi�os independentes e aut�nomos. Em outras palavras, a aplica��o � dividida em v�rias partes menores, cada uma com sua pr�pria responsabilidade e que se comunica com outras partes por meio de APIs bem definidas.\
Vantagens da Arquitetura Monol�tica:
- Simplicidade: A estrutura �nica facilita o desenvolvimento e a manuten��o, j� que todas as funcionalidades est�o no mesmo lugar. Isso reduz a complexidade de integra��o e permite uma vis�o unificada da aplica��o.
- Desempenho: Como todos os componentes da aplica��o est�o na mesma base de c�digo e rodando no mesmo processo, a comunica��o entre eles � mais r�pida e eficiente, sem a sobrecarga das chamadas de rede.
- Desdobramento e Escalonamento: A constru��o e o despliegue s�o mais diretos e r�pidos. N�o � necess�rio lidar com m�ltiplos servi�os e suas intera��es. O escalonamento da aplica��o pode ser feito verticalmente, aumentando os recursos do servidor �nico.
- Menor Custo Inicial: O desenvolvimento de uma aplica��o monol�tica pode ser menos custoso inicialmente, pois evita a complexidade associada � implementa��o e manuten��o de m�ltiplos servi�os e suas intera��es.
- Facilidade de Testes: A abordagem monol�tica facilita o teste de integra��o, pois todos os componentes est�o juntos e interagem diretamente no mesmo ambiente.

Vantagens da Arquitetura de Microservi�os:
- Resili�ncia: Falhas em um servi�o n�o afetam diretamente outros servi�os, aumentando a robustez e a capacidade de recupera��o da aplica��o como um todo.
- Desenvolvimento Descentralizado: Equipes diferentes podem trabalhar em microsservi�os distintos simultaneamente, permitindo uma entrega mais �gil e flex�vel.
- Tecnologias Diversificadas: Permite o uso de diferentes tecnologias e linguagens de programa��o para diferentes servi�os, otimiza��o de acordo com as necessidades espec�ficas de cada parte da aplica��o.
- Manuten��o e Atualiza��es: Atualiza��es e manuten��es podem ser realizadas em um microsservi�o sem a necessidade de impactar toda a aplica��o, facilitando a implementa��o de novas funcionalidades e corre��es de bugs.

### Por que escolhemos a arquitetura monol�tica?
Tendo isso em vista, nossa decis�o foi de seguir com a arquitetura monol�tica de acordo com os seguintes crit�rios:
- O projeto � relativamente pequeno e n�o requer a complexidade e a escalabilidade oferecidas pela arquitetura de microservi�os;
- Apenas uma linguagem de programa��o e a conex�o com um banco de dados s�o necess�rios para o desenvolvimento da aplica��o;
- Com a arquitetura monol�tica, podemos concentrar todo o desenvolvimento em uma �nica base de c�digo, simplificando a gest�o e a manuten��o;
- A comunica��o direta dentro de um �nico processo resulta em uma aplica��o mais �gil e com menor lat�ncia;
- A estrutura unificada facilita o gerenciamento do projeto e a realiza��o de testes, garantindo uma abordagem mais direta e integrada.
Assim, escolhemos a arquitetura monol�tica para garantir um desenvolvimento mais eficiente e menos complexo, adequando-se melhor �s necessidades e restri��es do nosso projeto.


### Tecnologias utilizadas
- **`Linguagem de Programa��o`**: C#;
- **`Framework`**: .NET Core 8.0;
- **`Banco de Dados`**: Oracle Database;
- **`Design Pattern`**: Repository Pattern;

## Instru��es para uso da aplica��o

**Execu��o da Aplica��o**:
    - Para iniciar a aplica��o, voc� deve dar play com a configura��o **`https`**. Isso pode ser feito diretamente dentro do seu Visual Studio (Ambiente de Desenvolvimento Integrado).

**Execu��o das requisi��es**:
    - Ap�s inicializar a aplica��o, uma p�gina web ser� aberta no seu navegador padr�o. Nela, voc� poder� visualizar a documenta��o da API, bem como realizar requisi��es para a mesma;
    - Para realizar a requisi��o desejada, basta clicar no endpoint desejado e, em seguida, no bot�o **`Try it out`**. Ap�s isso, voc� poder� preencher os campos necess�rios para a requisi��o e, por fim, clicar no bot�o **`Execute`**.


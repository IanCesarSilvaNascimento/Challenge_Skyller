
# Diretrizes do desafio

---

1. Criar uma conta no site [notion.so](http://notion.so) 

2. Abrir e duplicar o seguinte template: [Estoque](https://www.notion.so/Estoque-cf284c21a34a4d4ebaa930dd98d59bae) (para duplicar basta clicar em Duplicate ou Duplicar no canto superior direito da tela)

3. Ter uma conta no Google e criar uma planilha no Sheets com o título no seguinte padrão: NOME_SOBRENOME_SKY01

1. Você deverá pensar em soluções para os dois testes abaixo - “Registro de compra” e “Alerta Vermelho”
2. Depois, você deverá submeter suas resposta (seu plano de ação) conforme as instruções em  Como submeter suas respostas e próximos passos

## 💻 Registro de compra

### Registrar quando um cliente faz uma compra

Imagine que um cliente faça uma compra, gerando uma nova linha na tabela de “Compras”, na página “Estoque” - duplicada por você.
Para manter um padrão, você deve chamar o “ID da compra” da nova compra de “Compra 00090”.

Você deve pensar como criar (descrevendo seu plano de ação) um mecanismo que: quando uma nova compra for adicionada na tabela “Compras”, essa linha apareça automaticamente (ou via botão) na planilha do Google Sheets criada no passo 3.

---

## 🗣 Alerta Vermelho

### Avisar que é necessário comprar mais estoque

Imagine que suas vendas decolaram!

Você deve pensar como criar (descrevendo seu plano de ação) um mecanismo que: envie um e-mail para um certo endereço de e-mail (usar um e-mail próprio como teste) quando o status de algum produto fique como “🔆🔆🔆” na tabela “Produtos”, ou seja, avisando que o produto está acabando e que a empresa precisa comprar mais unidades.

# Plano de ação

---

- [x]  Leitura e entendimento do desafio

- [x]  Estudo de caso

Nessa etapa procurei conhecer o desafio e associar com alguma prática que atendesse os requisitos do teste de registro e o alerta. Verifiquei o site da empresa buscando conhecer um pouco sobre suas atividades. Logo então, percebi que a construção de uma API REST seria satisfatório porque permite alcançar  uma solução mais próxima da atividade da empresa (A ideia foi se basear em um sistema de compra de passagens pela internet). 

---

- [x]  Registro de compra

- [x]  Alerta vermelho

- [ ]  Google Sheets

Utilizei o DOCKER como plataforma de virtualização do SQLSERVER. 

Utilizei o AZURE DATA STUDIO como ferramenta de acesso ao banco de dados local.

Utilizei o VS CODE como editor de código. 

Utilizei o  POSTMAN como API CLIENT.

O primeiro passo foi construção dos modelos que representariam as tabelas de compras e inventário no banco de dados, como mostra a imagem abaixo:

![Capturar](https://user-images.githubusercontent.com/62857753/151733334-0fbfac1a-769c-4efb-baf3-c374604931a5.JPG)


Em seguida o banco de dados em memória e o mapeamento utilizando o Fluent Mapping - uma ferramenta do Entity Framework Core para ORM - Esse contexto é o responsável por associar as informações do cliente com o que será incluído no banco.

![Capturar](https://user-images.githubusercontent.com/62857753/151733396-862b1140-db0e-4474-a7fb-8edb47410ef9.JPG)

Depois foi construido o contexto de serviços: ativação de status, envio de e-mail e exportar .csv
![Captura de tela 2022-02-12 233927](https://user-images.githubusercontent.com/62857753/153735955-a0acd284-86b5-4626-b23f-a962f788c347.png)



Por fim foi feito o contexto de controladores, parametrizando as ações de get-create-update-delete do cliente. 
![Capturar](https://user-images.githubusercontent.com/62857753/151732844-69b4fffa-c6d4-439b-b3e6-061ff2bc6464.JPG)


# Considerações finais

---

O algoritmo desenvolvido atendeu e executou de forma satisfatória a maior parte dos itens propostos. Destaco um link para acesso ao vídeo de funcionamento disponível no campo abaixo.

# Links

---

[https://youtu.be/pii3PbyzJ9Q](https://youtu.be/pii3PbyzJ9Q)

[https://youtu.be/U4QiciX7iwE](https://youtu.be/U4QiciX7iwE)

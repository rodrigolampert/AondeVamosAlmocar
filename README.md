# Requisitos de ambiente necessários para compilar e rodar o software:
    * .NET Framework 4.6.1
    * Visual Studio 2015 ou mais recente

# Instruções de como utilizar o sistema:
    Na tela inicial, temos 3 opçoes
    * Acompanhar Votação
        -Permite acompanhar a Votação do dia de hoje, assim como as votações antereriores.
    * Votar
        -Permite selecionar uma pessoa e registrar o voto do restaurante que ela gostaria de almoçar hoje. 
    * Criar usuário
        -Permite criar um usuário

# O que vale destacar no código implementado?
    Foi criado um MVP, aonde é possível adicionar novo usuário, fazer novas votações, aconpanhar a votação atual assim como anteriores.
    Para isso, utilizei um projeto MVC, com Razor e Bootstrap para a parte web. Separei a camada do serviço das controlers, para que em 
    um possível upgrade possamos adicionar um proxy e assim integrar com, por exemplo, projeto mobile se maiores dificuldade.
    Utilize o StructureMap para injeção de dependencia. o IoC foi configurado apenas com o mapeamento de Interfaces e Serviços.
    Os testes foram criando a partir o projeto web.

# O que poderia ser feito para melhorar o sistema?
    O sistema pode ser melhorado com a implementação de um sistema de desempado.
    Também podemos melhorá-lo adicionando uma camada Mobile, pois nem sempre os usuários vão estar na frente do computador.
    Outro ponto seria criar uma funcionalidade de envio de mensagem (e-mail, SMS, WhatsApp) do Restaurante ganhador para os usuários.
    Criação de CRUDs para as principais funcionalidades.

# Algo a mais que você tenha a dizer
    Posso dizer que a arquitetura que selecionei para esse projeto está meio defasada. Após o inicio da codificação, percebi que poderia
    ter utilizado, por exemplo, Web API ao invés de serviços. Também poderia ter substituído por microserviços. Para um melhor 
    escalonamento dos microserviços, também trocaria .NET Core.
    
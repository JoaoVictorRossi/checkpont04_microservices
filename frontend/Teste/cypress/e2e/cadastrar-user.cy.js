function gerarStringAleatoria(tamanho) {
  const caracteres = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
  let resultado = '';
  
  for (let i = 0; i < tamanho; i++) {
    const indice = Math.floor(Math.random() * caracteres.length);
    resultado += caracteres[indice];
  }
  
  return resultado;
}

describe('template spec', () => {
  it('passes', () => {
    cy.visit('http://127.0.0.1:5500/login.html')
    cy.get('#loginEmail').type('x2@gmail.com')
    cy.get('#loginPassword').type('123456')
    cy.get('.btn').click()
    cy.get('#loginError').should('contain','Usuário ou senha inválidos!' )
    cy.get(':nth-child(5) > #btnCadastrar').click()
   
    //Cadastrar
    const nome = `${gerarStringAleatoria(5)}`;
    const email = `${nome}@gmail.com`;
    const password = `${gerarStringAleatoria(5)}`;
    cy.get('#registerName').type(nome)
    cy.get('#registerEmail').type(email)
    cy.get('#registerPassword').type(password)
    cy.get('.btn').click()

    //logar novamente
    cy.get('#loginEmail').type(email)
    cy.get('#loginPassword').type(password)
    cy.get('.btn').click()
    cy.get('h2').should('contain', 'Lista de Usuários')

    //entrar pela home
    cy.visit('http://127.0.0.1:5500/index.html')

  })
})
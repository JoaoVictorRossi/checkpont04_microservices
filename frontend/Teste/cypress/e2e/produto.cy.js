describe('template spec', () => {
  it('passes', () => {
    cy.visit('http://127.0.0.1:5500/index.html')
    cy.get('#btnCadastro').click()

    cy.get('#produtoName').type('Teclado Gamer')
    cy.get('#precoProduto').type('800')
    cy.get('#quantidade').type('32')
    cy.get('#dataCriacao').type('2024-10-20')
    cy.get('.btn').click()
  })
})
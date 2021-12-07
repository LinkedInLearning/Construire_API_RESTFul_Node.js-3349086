/// <reference types="cypress" />

describe('LinkedIn Learning API', () => {
    const url = 'https://localhost:5001/api';

    it('GET product by ID', () => {
        cy.request(`${url}/products/1`).its('body').its('id').should('eq', 1);
        cy.request(`${url}/products/2`).its('body').its('id').should('eq', 2);
        cy.request(`${url}/products/3`).its('body').its('id').should('eq', 3);
    })
});
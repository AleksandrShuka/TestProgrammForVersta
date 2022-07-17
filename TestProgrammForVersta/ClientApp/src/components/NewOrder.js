import React, { Component } from 'react';
import { Container, Form, Button } from 'react-bootstrap';


export class NewOrder extends Component {
    static displayName = NewOrder.name;

    constructor(props) {
        super(props);
        this.state = {
            SenderCity: "",
            SenderAddress: "",
            RecieverCity: "",
            RecieverAddress: "",
            Weight: "",
            Date: ""
        };

        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleInputChange = this.handleInputChange.bind(this);
    }

    handleSubmit(event) {
        event.preventDefault();
        if (window.confirm("Создать заказ?")) {
            this.createOrder();
            event.target.reset();
        }
    }

    handleInputChange(event) {
        const target = event.target;
        const value = target.value;
        const name = target.name;

        this.setState({
            [name]: value
        });
    }

    async createOrder() {
        const settings = {
            method: 'POST',
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(this.state)
        };

        const response = await fetch("order/create", settings);
    }

    render() {
        return (
            <Container fluid>
                <Form onSubmit={this.handleSubmit}>
                    <Form.Group className="mb-3" onChange={this.handleInputChange}>
                        <Form.Label>Город отправителя</Form.Label>
                        <Form.Control name="SenderCity" type="text" required placeholder="Москва" />
                    </Form.Group>
                    <Form.Group className="mb-3" onChange={this.handleInputChange}>
                        <Form.Label>Адрес отправителя</Form.Label>
                        <Form.Control name="SenderAddress" type="text" required placeholder="ул. Пушкина, д. 7, кв. 10" />
                    </Form.Group>
                    <Form.Group className="mb-3" onChange={this.handleInputChange}>
                        <Form.Label>Город получателя</Form.Label>
                        <Form.Control name="RecieverCity" type="text" required placeholder="Москва" />
                    </Form.Group>
                    <Form.Group className="mb-3" onChange={this.handleInputChange}>
                        <Form.Label>Адрес получателя</Form.Label>
                        <Form.Control name="RecieverAddress" type="text" required placeholder="ул. Пушкина, д. 7, кв. 10" />
                    </Form.Group>
                    <Form.Group className="mb-3" onChange={this.handleInputChange}>
                        <Form.Label>Вес груза, кг</Form.Label>
                        <Form.Control name="Weight" type="number" step="any" required placeholder="1.2" />
                    </Form.Group>
                    <Form.Group className="mb-3" onChange={this.handleInputChange}>
                        <Form.Label>Дата забора груза</Form.Label>
                        <Form.Control name="Date" type="date" required />
                    </Form.Group>
                    <div className="d-grid gap-2">
                        <Button variant="primary" type="submit">Создать заказ</Button>
                    </div>
                </Form>
            </Container>
        );
    }
}

import React, { Component } from 'react';
import { Container } from 'react-bootstrap';
import Table from 'react-bootstrap/Table';


export class Orders extends Component {
    static displayName = Orders.name;

    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true };
    }

    componentDidMount() {
        this.populateOrderData();
    }

    static renderForecastsTable(forecasts) {
        return (
            <Table striped bordered hover>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Город отправителя</th>
                        <th>Адрес отправителя</th>
                        <th>Город получателя</th>
                        <th>Адрес получателя</th>
                        <th>Вес груза, кг</th>
                        <th>Дата забора груза</th>
                    </tr>
                </thead>
                <tbody>
                    {forecasts.map(forecast =>
                        <tr key={forecast.id}>
                            <td>{forecast.id}</td>
                            <td>{forecast.senderCity}</td>
                            <td>{forecast.senderAddress}</td>
                            <td>{forecast.recieverCity}</td>
                            <td>{forecast.recieverAddress}</td>
                            <td>{forecast.weight}</td>
                            <td>{(new Date(forecast.date)).toLocaleDateString()}</td>
                        </tr>
                    )}
                </tbody>
            </Table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Orders.renderForecastsTable(this.state.forecasts);

        return (
            <Container fluid>
                {contents}
            </Container>
        );
    }

    async populateOrderData() {
        const response = await fetch('order');
        const data = await response.json();

        this.setState({ forecasts: data, loading: false });
    }
}

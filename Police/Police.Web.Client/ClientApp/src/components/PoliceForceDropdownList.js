import React, { Component } from 'react';

export class PoliceForceDropdownList extends Component {
    constructor(props) {
        super(props);

        this.state = { value: '', policeforces: [] };

        this.handleChange = this.handleChange.bind(this);
    }

    componentDidMount() {
        //Fetch the data to populate the component
        this.populatePoliceForces();
    }

    handleChange(event) {
        this.props.onUpdate(event.target.value);
        this.setState({ value: event.target.value });
    }

    render() {
        return (
            <div>
                <select onChange={this.handleChange} value={this.state.value}>
                    {this.state.policeforces.map((policeForce) => <option key={policeForce.id} value={policeForce.id}>{policeForce.name}</option>)}
                </select>
            </div>
        )
    }

    async populatePoliceForces() {
        const response = await fetch('/policeforce');
        const result = await response.json();
        this.setState({ policeforces: result });
    }
}
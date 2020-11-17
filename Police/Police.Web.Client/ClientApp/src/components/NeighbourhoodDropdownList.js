import React, { Component } from 'react';

export class NeighbourhoodDropdownList extends Component {
    constructor(props) {
        super(props);

        this.state = { value: '', neighbourhoods: [] };

        this.handleChange = this.handleChange.bind(this);
    }    

    handleChange(event) {
        this.props.onNeighbourhoodSelected(event.target.value);
        this.setState({ value: event.target.value });
    }

    componentDidUpdate(prevProps) {
        //Fetch the data to populate the component
        if (this.props.selectedPoliceForce !== prevProps.selectedPoliceForce) {
            this.populateNeighbourhoods();
        }
    }

    render() {
        return (
            <div>
                <select onChange={this.handleChange} value={this.state.value}>
                    {this.state.neighbourhoods.map((neighbourhood) => <option key={neighbourhood.id} value={neighbourhood.id}>{neighbourhood.name}</option>)}
                </select>
            </div>
        )
    }

    async populateNeighbourhoods() {
        const response = await fetch(`/neighbourhood?policeforce=${this.props.selectedPoliceForce}`);
        const result = await response.json();
        this.setState({ neighbourhoods: result });
    }
}
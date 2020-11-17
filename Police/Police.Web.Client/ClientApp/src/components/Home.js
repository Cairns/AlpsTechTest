import React, { Component } from 'react';
import { PoliceForceDropdownList } from './PoliceForceDropdownList';
import { NeighbourhoodDropdownList } from './NeighbourhoodDropdownList';
import { StopAndSearchGrid } from './StopAndSearchGrid';

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = {
            selectedPoliceForce: "",
            selectedNeighbourhood: ""
        }
    }

    onUpdate = (value) => {
        this.setState({
            selectedPoliceForce: value
        })
    };

    onNeighbourhoodSelected = (value) => {
        this.setState({
            selectedNeighbourhood: value
        });
    };

    render() {
        return (
            <div>
                <p>Select the Police Force and then the Neighbourhood to view a list of Stop and Searches in that area</p>

                <div>
                    <h1>Police Force</h1>
                    <PoliceForceDropdownList onUpdate={this.onUpdate} />
                </div>

                <div>
                    <h1>Neighbourhood</h1>
                    <NeighbourhoodDropdownList onNeighbourhoodSelected={this.onNeighbourhoodSelected} selectedPoliceForce={this.state.selectedPoliceForce} />
                </div>

                <div>
                    <h1>Stop and Searches</h1>
                    <StopAndSearchGrid selectedPoliceForce={this.state.selectedPoliceForce} selectedNeighbourhood={this.state.selectedNeighbourhood} />
                </div>
            </div>
        );
    }
}

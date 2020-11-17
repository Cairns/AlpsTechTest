import React, { Component } from 'react';
import Moment from 'react-moment';

export class StopAndSearchGrid extends Component {
    constructor(props) {
        super(props);

        this.state = { value: '', stopAndSearches: [] };
    }

    componentDidUpdate(prevProps) {
        //Fetch the data to populate the component
        if (this.props.selectedNeighbourhood !== prevProps.selectedNeighbourhood) {
            this.populateStopAndSearches();
        }
    }

    //renderTableHeader() {
    //    return (
    //        <tr>
    //            <th>1</th>
    //            <th>2</th>
    //            <th>3</th>
    //            <th>4</th>
    //        </tr>
    //        )
    //}

    //renderTableRows(rows) {
    //    return rows.map((stopAndSearch, index) => {
    //        return (
    //            <tr key={stopAndSearch.id}>
    //                <td>{stopAndSearch.datetime}</td>
    //                <td>{stopAndSearch.gender}</td>
    //                <td>{stopAndSearch.agerange}</td>
    //                <td>{stopAndSearch.objectofsearch}</td>
    //            </tr>
    //            )
    //    })
    //}

    //renderTableRow(stopAndSearch) {
    //    return (
    //        <tr key={stopAndSearch.id}>
    //            <td>{stopAndSearch.datetime}</td>
    //            <td>{stopAndSearch.gender}</td>
    //            <td>{stopAndSearch.agerange}</td>
    //            <td>{stopAndSearch.objectofsearch}</td>
    //        </tr>
    //    )
    //}

    render() {
        const rows = [];

        if (this.state.stopAndSearches !== undefined) {
            this.state.stopAndSearches.forEach((stopAndSearch) => {
                rows.push(
                    <tr key={stopAndSearch.id}>
                        <td><Moment format="DD/MM/YYYY HH:mm">{stopAndSearch.dateTime}</Moment></td>
                        <td>{stopAndSearch.gender}</td>
                        <td>{stopAndSearch.ageRange}</td>
                        <td>{stopAndSearch.objectOfSearch}</td>
                    </tr>)
            });
        }

        if (this.props.selectedNeighbourhood === "") {
            return null;
        }
        else {
            return (
                <div>
                    <table className="table table-bordered">
                        <thead className="thead-dark">
                            <tr>
                                <th>Timestamp</th>
                                <th>Gender</th>
                                <th>Age Range</th>
                                <th>Object of Search</th>
                            </tr>
                        </thead>
                        <tbody>{rows}</tbody>
                    </table>
                </div>
            )
        }
    }

    async populateStopAndSearches() {
        const response = await fetch(`/stopandsearch?policeforce=${this.props.selectedPoliceForce}&neighbourhood=${this.props.selectedNeighbourhood}`);
        const result = await response.json();
        this.setState({ stopAndSearches: result });
    }
}
import React, { Component, FormEventHandler } from "react";
import "./App.css";
import { Calculator } from "./calculator";
import moment from "moment";

class App extends Component<
  {},
  {
    items: any[];
    total: number;
    newItem: {
      adType: number;
      userType: number;
      price: number;
      endDate: string;
    };
  }
> {
  constructor(props: {} | Readonly<{}>) {
    super(props);

    this.state = {
      items: [],
      total: 0,
      newItem: {
        adType: -1,
        userType: -1,
        price: 100,
        endDate: moment().format("YYYY-MM-DD"),
      },
    };
  }

  onItemTypeChange: FormEventHandler = (event) => {
    const { newItem } = this.state;

    this.setState({
      newItem: {
        userType: newItem.userType,
        price: newItem.price,
        endDate: newItem.endDate,
        adType: parseInt((event.target as HTMLSelectElement).value, 10),
      },
    });
  };

  onUserTypeChanged: FormEventHandler = (event) => {
    const { newItem } = this.state;

    this.setState({
      newItem: {
        adType: newItem.adType,
        price: newItem.price,
        endDate: newItem.endDate,
        userType: parseInt((event.target as HTMLSelectElement).value, 10),
      },
    });
  };

  onNewItemSubmit: FormEventHandler = (event) => {
    event.preventDefault();

    const calc = new Calculator();
    const { newItem } = this.state;
    const fee = calc.getFee(newItem);

    // update total
    this.setState({
      total: this.state.total + fee,
    });
  };

  onPriceChanged: FormEventHandler = (event) => {
    const { newItem } = this.state;

    this.setState({
      newItem: {
        adType: newItem.adType,
        userType: newItem.userType,
        endDate: newItem.endDate,
        price: parseInt((event.target as HTMLInputElement).value, 10),
      },
    });
  };

  onEndDateChanged: FormEventHandler = (event) => {
    const { newItem } = this.state;

    this.setState({
      newItem: {
        adType: newItem.adType,
        userType: newItem.userType,
        price: newItem.price,
        endDate: (event.target as HTMLInputElement).value,
      },
    });
  };

  render() {
    const { newItem, total } = this.state;

    return (
      <div className="App">
        <header className="App-header">
          <h1 className="App-title">Welcome to Solid Fee Calculator</h1>
        </header>
        <div className="App-page">
          <h2>Items</h2>

          <p>Total fees: {total} </p>

          <h3>Register new item</h3>
          <form className="New-item-form" onSubmit={this.onNewItemSubmit}>
            <div className="form-group">
              <label>You are</label>
              <select
                className="form-control"
                id="itemType"
                defaultValue="-1"
                onChange={this.onUserTypeChanged}
              >
                <option value="-1">Select</option>
                <option value="0">Person</option>
                <option value="1">Company</option>
              </select>
            </div>

            <div className="form-group">
              <label>Item Type</label>
              <select
                className="form-control"
                id="itemType"
                defaultValue="-1"
                onChange={this.onItemTypeChange}
              >
                <option value="-1">Select </option>
                <option value="0">Auction</option>
                <option value="1">Buy it now</option>
              </select>
            </div>

            <div className="form-group">
              <label htmlFor="itemType">Price</label>
              <input
                className="form-control"
                type="number"
                value={newItem.price}
                onChange={this.onPriceChanged}
              />
            </div>

            <div className="form-group">
              <label htmlFor="itemType">End date</label>
              <input
                className="form-control"
                type="text"
                value={newItem.endDate}
                onChange={this.onEndDateChanged}
              />
            </div>

            <input type="submit" className="btn btn-primary" value="Submit" />
          </form>
        </div>
      </div>
    );
  }
}

export default App;

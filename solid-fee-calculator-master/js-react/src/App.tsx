import React, { Component, FormEventHandler, useReducer } from "react";
import "./App.css";
import { Calculator } from "./calculator";
import moment from "moment";
import { FeeItem } from "./Interfaces/FeeItem";
import { ItemList } from "./ItemList/ItemList";

interface AppState {
  items: FeeItem[];
  total: number;
  newItem: FeeItem;
}
const calculator = new Calculator();
export default function App() {
  const [state, dispatch] = useReducer(reducer, {
    items: [],
    total: 0,
    newItem: {
      adType: -1,
      userType: -1,
      price: 100,
      endDate: moment().format("YYYY-MM-DD"),
    },
  });

  const onItemTypeChange: FormEventHandler = (event) => {
    dispatch({
      type: "update_ad_type",
      payload: parseInt((event.target as HTMLSelectElement).value, 10),
    });
  };

  const onUserTypeChanged: FormEventHandler = (event) => {
    dispatch({
      type: "update_user_type",
      payload: parseInt((event.target as HTMLSelectElement).value, 10),
    });
  };

  const onNewItemSubmit: FormEventHandler = (event) => {
    event.preventDefault();
    dispatch({ type: "add_item", payload: state.newItem });
  };

  const onPriceChanged: FormEventHandler = (event) => {
    dispatch({
      type: "update_price",
      payload: parseInt((event.target as HTMLInputElement).value, 10),
    });
  };

  const onEndDateChanged: FormEventHandler = (event) => {
    dispatch({
      type: "update_end_date",
      payload: (event.target as HTMLInputElement).value,
    });
  };

  const { newItem, total, items } = state;

  return (
    <div className="App">
      <header className="App-header">
        <h1 className="App-title">Welcome to Solid Fee Calculator</h1>
      </header>
      <div className="App-page">
        <h2>Items</h2>

        <ItemList items={items}></ItemList>

        <p>Total fees: ${total} </p>

        <h3>Register new item</h3>
        <form className="New-item-form" onSubmit={onNewItemSubmit}>
          <div className="form-group">
            <label>You are</label>
            <select
              className="form-control"
              id="itemType"
              defaultValue=""
              required
              onChange={onUserTypeChanged}
            >
              <option value="">Select</option>
              <option value="0">Person</option>
              <option value="1">Company</option>
            </select>
          </div>

          <div className="form-group">
            <label>Item Type</label>
            <select
              className="form-control"
              id="itemType"
              defaultValue=""
              required
              onChange={onItemTypeChange}
            >
              <option value="">Select </option>
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
              onChange={onPriceChanged}
            />
          </div>

          <div className="form-group">
            <label htmlFor="itemType">End date</label>
            <input
              className="form-control"
              type="date"
              value={newItem.endDate}
              onChange={onEndDateChanged}
            />
          </div>

          <input type="submit" className="btn btn-primary" value="Submit" />
        </form>
      </div>
    </div>
  );
}

type actionTypes =
  | "add_item"
  | "update_price"
  | "update_end_date"
  | "update_user_type"
  | "update_ad_type";

function reducer(state: AppState, action: { type: actionTypes; payload: any }) {
  switch (action.type) {
    case "add_item":
      return {
        ...state,
        items: [
          ...state.items,
          { ...action.payload, price: calculator.getFee(action.payload) },
        ],
        total: calculator.getFee(action.payload),
      };
    case "update_price":
      return {
        ...state,
        newItem: {
          ...state.newItem,
          price: action.payload,
        },
      };
    case "update_end_date":
      return {
        ...state,
        newItem: {
          ...state.newItem,
          endDate: action.payload,
        },
      };
    case "update_user_type":
      return {
        ...state,
        newItem: {
          ...state.newItem,
          userType: action.payload,
        },
      };
    case "update_ad_type":
      return {
        ...state,
        newItem: {
          ...state.newItem,
          adType: action.payload,
        },
      };
    default:
      return state;
  }
}

import React, { Component } from "react";
import { FeeItem } from "../Interfaces/FeeItem";
import "./ItemList.css";
import { UserTypeEnum } from "../Enums/UserTypeEnum";
import { AdTypeEnum } from "../Enums/AdTypeEnum";

export function ItemList({ items }: { items: FeeItem[] }) {
  const itemList = items.map((item) => (
    <div className="card">
      <div className="card-body">
        <h5 className="card-title">User Type: {UserTypeEnum[item.userType]}</h5>
        <h5 className="card-title">Ad Type: {AdTypeEnum[item.adType]}</h5>
        <h6 className="card-subtitle mb-2 text-muted">
          Ad ends on: {item.endDate}
        </h6>
        <p className="card-text">Ad buy: ${item.price}</p>
      </div>
    </div>
  ));
  return <>{itemList}</>;
}

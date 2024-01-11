import React, { Component } from "react";
import { Route, Routes } from "react-router-dom";
import AppRoutes from "./AppRoutes";
// import { Layout } from './components/Layout';
import Sidebar from "./components/Sidebar/index.js";
import "./custom.css";

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <div style={{ display: "flex" }}>
        <div style={{ flex: 0.25 }}>
          <Sidebar />
        </div>
        <div style={{ flex: 1, padding: "50px" }}>
          <Routes>
            {AppRoutes.map((route, index) => {
              const { element, ...rest } = route;
              return <Route key={index} {...rest} element={element} />;
            })}
          </Routes>
        </div>
      </div>
    );
  }
}

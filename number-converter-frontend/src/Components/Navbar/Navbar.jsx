import React from "react";
import { NavLink } from "react-router-dom";
import styles from "./Navbar.module.css";

const Navbar = ({ resetNumbers }) => {
  return (
    <div className={styles.Color}>
    <nav className={styles.Navbar}>
        <NavLink to="/" className={styles.Title}>
          <h1>Number Converter</h1>
        </NavLink>

        <ul className={styles.menuItems}>
          <li className="nav-item">
            <NavLink to="/" className={`${styles.item} nav-link`}>
              Home
            </NavLink>
          </li>
        </ul>
    </nav>
    </div>
  );
};

export default Navbar;

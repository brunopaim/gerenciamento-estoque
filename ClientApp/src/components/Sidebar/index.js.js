// React
import React, { useState } from "react";
import { Link, useLocation } from "react-router-dom";

// Material UI
import Drawer from "@mui/material/Drawer";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemIcon from "@mui/material/ListItemIcon";
import ListItemText from "@mui/material/ListItemText";

// Styles
import styled from "@emotion/styled";

// Constants
import { sidebarItems } from "./constants";

const ColoredIcon = styled("span")`
  color: ${(props) => (props.selected ? "blue" : "black")};
`;

const Sidebar = () => {
  const location = useLocation();
  const [selectedItem, setSelectedItem] = useState(null);

  const handleItemClick = (item) => {
    setSelectedItem(item.id);
  };

  return (
    <Drawer variant="permanent">
      <List>
        {sidebarItems.map((item) => (
          <ListItem
            key={item.id}
            button
            component={Link}
            to={item.url}
            selected={location.pathname === item.url}
            onClick={() => handleItemClick(item)}
          >
            <ListItemIcon>
              <ColoredIcon selected={location.pathname === item.url}>
                {item.icon}
              </ColoredIcon>
            </ListItemIcon>
            <ListItemText primary={item.label} />
          </ListItem>
        ))}
      </List>
    </Drawer>
  );
};

export default Sidebar;

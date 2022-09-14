import React from "react"
import {Route, Routes} from "react-router-dom";
import Dashboard from "./Dashboard";

function DashboardRoutes() {
    return (
        <Routes>
            <Route index element={<Dashboard/>}/>
        </Routes>
    )
}

export default React.memo(DashboardRoutes);
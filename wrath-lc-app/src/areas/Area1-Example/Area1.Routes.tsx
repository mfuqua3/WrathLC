import React from "react";
import {Route, Routes} from "react-router-dom";
import Area1 from "./Area1";

function Area1Routes() {
    return (
        <Routes>
            <Route index element={<Area1/>}/>
        </Routes>
    )

}

export default React.memo(Area1Routes);
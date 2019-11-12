import * as React from "react";
import * as ReactDOM from "react-dom";

import { Multilanguage } from "./components/Multilanguage";

ReactDOM.render(
    <Multilanguage compiler="TypeScript" framework="React" />,
    document.getElementById("example")
);
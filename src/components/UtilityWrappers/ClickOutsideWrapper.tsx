import React, { useEffect, useRef } from "react";
import { Box } from "@mui/material";
import useClickOutside from "../../utils/hooks/useClickOutside";
import { WrapperProps } from "./WrapperProps";

interface ClickOutsideWrapperProps extends WrapperProps {
    isOpen: boolean;
    action: () => void;
}

function ClickOutsideWrapper(props: ClickOutsideWrapperProps): JSX.Element {
    const wrapperRef = useRef(null);
    const [clickedOutside] = useClickOutside(wrapperRef, props.isOpen);

    useEffect(() => {
        if (clickedOutside && props.isOpen) {
            props.action();
        }
    }, [clickedOutside]);

    return (
        <Box height={"100%"} width={"100%"} ref={wrapperRef}>
            {props.children}
        </Box>
    );
}

export default React.memo(ClickOutsideWrapper);

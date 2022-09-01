import { TextField } from "@mui/material";
import { FieldHookConfig, useField } from "formik";
import React from "react";

interface OtherProps {
    label: string;
    type: string;
    helperText?: string;
}

const FormikTextField = (props: OtherProps & FieldHookConfig<string | number>): JSX.Element => {

    const [field, meta] = useField(props);

    return (
        <TextField
            fullWidth
            variant="outlined"
            disabled={props.disabled}
            type={props.type === "number" ? "number" : "text"}
            id={field.name}
            name={field.name}
            value={field.value}
            onChange={field.onChange}
            label={props.label}
            error={meta.touched && Boolean(meta.error)}
            helperText={props.helperText ?? (meta.touched && meta.error)}
        />

    );
};

export default React.memo(FormikTextField);

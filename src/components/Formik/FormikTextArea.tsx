import {TextField} from "@mui/material";
import {FieldHookConfig, useField} from "formik";
import React from "react";

interface OtherProps {
    label: string;
    rows: number;
}

const FormikTextArea = (props: OtherProps & FieldHookConfig<string | number>): JSX.Element => {

    const [field, meta] = useField(props);

    return (
        <TextField
            fullWidth
            multiline
            rows={props.rows}
            variant="outlined"
            disabled={props.disabled}
            type={"text"}
            id={field.name}
            name={field.name}
            label={props.label}
            value={field.value}
            onChange={field.onChange}
            error={meta.touched && Boolean(meta.error)}
            helperText={meta.touched && meta.error}
        />

    );
};

export default React.memo(FormikTextArea);

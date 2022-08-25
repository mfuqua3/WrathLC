import { FormControlLabel, Switch } from "@mui/material";
import { FieldHookConfig, useField } from "formik";
import React from "react";

interface OtherProps {
    label: string;
}

const FormikSwitch = (props: OtherProps & FieldHookConfig<boolean | string>): JSX.Element => {

    const [field] = useField(props);

    return (
        <FormControlLabel
            control={
                <Switch
                    checked={field.value === "true" || field.value === true}
                    id={props.id}
                    disabled={props.disabled}
                    {...field}
                />
            }
            label={props.label}
        />
    );
};

export default React.memo(FormikSwitch);

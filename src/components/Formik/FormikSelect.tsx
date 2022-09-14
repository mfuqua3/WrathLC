import {ErrorMessage, Field, FieldHookConfig, FieldInputProps, useField} from "formik";
import React, {ReactNode} from "react";
import {FormControl, FormHelperText, InputLabel, MenuItem, Select} from "@mui/material";

export interface FormikSelectItem {
    content: ReactNode;
    value: string | number;
}

interface OtherProps {
    label: string;
    items: Array<FormikSelectItem>;
    fullWidth?: boolean;
}

interface MaterialSelectProps extends FieldInputProps<string | number> {
    errorMessage?: string;
    error?: boolean;
    children: React.ReactNode;
    label: string;
    fullWidth?: boolean;
}

export const MaterialSelect = (props: MaterialSelectProps & FieldHookConfig<string | number>): JSX.Element => {
    const {
        errorMessage,
        error,
        children,
        label,
        value,
        name,
        onChange
    } = props;

    return (
        <FormControl fullWidth={props.fullWidth ?? true} error={error}>
            <InputLabel>{label}</InputLabel>
            <Select label={label} name={name} fullWidth={props.fullWidth ?? true} onChange={onChange} value={value}
                    disabled={props.disabled}>
                {typeof props.value === "string" ?
                    <MenuItem value={""}>{`Select ${label}...`}</MenuItem> :
                    <MenuItem value={0}>{`Select ${label}...`}</MenuItem>
                }
                {children}
            </Select>
            <FormHelperText>{errorMessage}</FormHelperText>
        </FormControl>
    );
};

const FormikSelect = (props: OtherProps & FieldHookConfig<string | number>): JSX.Element => {
    const [field, meta] = useField(props);
    const {items, label} = props;

    return (
        <Field
            as={MaterialSelect}
            label={label}
            disabled={props.disabled}
            error={meta.touched && !!meta.error}
            errorMessage={<ErrorMessage name={field.name}/>}
            fullWidth={props.fullWidth ?? true}
            {...field}
        >
            {
                items.map(item => (
                    <MenuItem key={item.value} value={item.value}>{item.content}</MenuItem>
                ))
            }
        </Field>
    );
};

export default React.memo(FormikSelect);

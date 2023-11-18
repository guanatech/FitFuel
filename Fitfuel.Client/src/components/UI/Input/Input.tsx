import { FC } from "react";
import styles from "./input.module.scss";

interface InputProps extends React.ComponentProps<"input"> {}

const Input: FC<InputProps> = ({ type, placeholder, width }) => {
  return (
    <input
      className={styles.root}
      type={type}
      placeholder={placeholder}
      width={width}
    />
  );
};

export default Input;

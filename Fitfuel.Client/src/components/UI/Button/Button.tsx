import { FC, PropsWithChildren } from "react";
import styles from "./button.module.scss";

interface ButtonProps extends React.ComponentProps<"button"> {
  width?: string | number;
  height?: string;
}

const Button: FC<PropsWithChildren<ButtonProps>> = (props) => {
  return (
    <button type="submit"
      style={{ width: props.width, height: props.height }}
      className={styles.root}
      onClick={props.onClick}
    >
      {props.children}
    </button>
  );
};

export default Button;

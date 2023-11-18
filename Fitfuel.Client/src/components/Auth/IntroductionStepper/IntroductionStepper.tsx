import { useState } from "react";
import Button from "../../UI/Button/Button";
import LevelStep from "./Steps/LevelStep";
import ParametersStep from "./Steps/ParametersStep";
import UsernameStep from "./Steps/UsernameStep";
import styles from "./introductionStepper.module.scss";

const steps = [
  {
    number: 1,
    title: "Давайте знакомиться!",
    subtitle:
      "Команда FitFuel уже готовит для вас личный план! Укажите информацию о себе для эффективной работы с нами.",
    stepElement: <UsernameStep />,
  },
  {
    number: 2,
    title: "Хотим узнать о вас ещё!",
    subtitle:
      "Благодаря этим данным мы сможем наиболее точно сформировать для вас программу",
    stepElement: <ParametersStep />,
  },
  {
    number: 3,
    title: "И самое главное...",
    subtitle: "Почти готово. Выберите подходящие пункты и можем начинать!",
    stepElement: <LevelStep />,
  },
];

const IntroductionStepper = () => {
  const [currentStep, setCurrentStep] = useState(1);
  const [complete, setComplete] = useState(false);

  return (
    <div className={styles.root}>
      {steps.map(
        (step, index) =>
          currentStep === step.number && (
            <div key={index}>
              <h1 className={styles.title}>{step.title}</h1>
              <p className={styles.subtitle}>{step.subtitle}</p>
              {step.stepElement}
              <div className={styles.btn}>
                <Button
                  onClick={() => {
                    currentStep === steps.length
                      ? setComplete(true)
                      : setCurrentStep((prev) => prev + 1);
                  }}
                  width={300}
                >
                  Продолжить
                </Button>
              </div>
            </div>
          )
      )}
    </div>
  );
};

export default IntroductionStepper;

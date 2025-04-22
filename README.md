# Design Patterns Summary

## 1. Resource Acquisition Is Initialization (RAII)

**Тип шаблону:** Породжуючий (Creational Pattern)  
**Призначення:** Автоматичне управління ресурсами через життєвий цикл об’єкта  
**Джерело:** [Концепция RAII](https://habr.com/ru/companies/otus/articles/778942/)

### Опис:
RAII (Resource Acquisition Is Initialization) — це концепція, за якої ресурс прив’язується до об'єкта: він виділяється при створенні об'єкта та автоматично звільняється при його знищенні. Це забезпечує безпечне та надійне управління ресурсами без необхідності ручного контролю.

RAII допомагає уникати утечок пам’яті, неправильного закриття файлів і помилок у роботі з ресурсами. Особливо корисною ця концепція є в умовах виникнення виключень, адже ресурси гарантовано звільняються деструкторами, навіть якщо сталася помилка.

Код із використанням RAII стає чистішим і зрозумілішим: логіка управління ресурсами інкапсульована в об'єктах, що спрощує супровід і знижує ризик помилок. RAII підходить для роботи з пам’яттю, файлами, з’єднаннями та іншими ресурсами, зокрема й у багатопотокових середовищах.

Завдяки цій концепції створювати надійні програми простіше — ресурси використовуються ефективно, а звільнення відбувається автоматично й безпечно.

### Основні складові:
- **Resource** — ресурс, який потрібно отримати (наприклад, файл, з'єднання, м'ютекс).
- **RAIIWrapper** — клас-обгортка, який:
  - у **конструкторі** викликає `acquire()` — ініціалізує ресурс
  - у **деструкторі** викликає `release()` — звільняє ресурс
- **Клієнтський код** — створює об’єкт `RAIIWrapper` і більше не хвилюється про звільнення ресурсу.

### UML-діаграми
**Діаграма класів**  
```mermaid
classDiagram
    class RAIIObject {
        -resource : Resource
        +RAIIObject()
        +~RAIIObject()
        +useResource()
    }

    class Resource {
        +acquire()
        +release()
    }

    RAIIObject --> Resource : owns
```

**Діаграма взаємодії**  
```mermaid
sequenceDiagram
    participant Main
    participant RAIIObject
    participant Resource

    Main->>RAIIObject: створення об’єкта
    RAIIObject->>Resource: acquire()
    Main->>RAIIObject: useResource()
    Note over RAIIObject: обробка винятку (опціонально)
    RAIIObject-->>Resource: release() (автоматично в деструкторі)
```

**Діаграма станів**
```mermaid
stateDiagram-v2
    [*] --> Initialized
    Initialized --> ResourceAcquired: створення об'єкта
    ResourceAcquired --> UsingResource: виклик useResource()
    UsingResource --> ResourceReleased: вихід з області видимості або виключення
    ResourceReleased --> [*]
```


## 2. Decorator

**Тип шаблону:** Структурний (Structural Pattern)  
**Призначення:** Дає змогу динамічно додавати об’єктам нову функціональність, загортаючи їх у корисні «обгортки»  
**Джерело:** [Refactoring Guru - Декоратор](https://refactoring.guru/uk/design-patterns/decorator)

### Опис:
Декоратор дозволяє динамічно додавати об’єктам нову поведінку, не змінюючи їхній код. Це досягається за рахунок обгортання об'єкта в інші об'єкти-декоратори, які реалізують той самий інтерфейс і розширюють або змінюють функціональність.   

**Принцип роботи:**   
1. Створюється базовий об'єкт (ConcreteComponent).   
2. Він обгортається у декоратор (ConcreteDecorator).   
3. Кожен декоратор реалізує ту саму інтерфейсну структуру та додає свою поведінку.   
4. Можна вкладати декоратори один в одного, комбінуючи функціональність.   

### Основні складові:
- **Component (Компонент)** - абстрактний інтерфейс або базовий клас, який визначає стандартну поведінку об'єктів. Визначає контракт, спільний для всіх об'єктів (як основних, так і декораторів).   
- **ConcreteComponent (Конкретний компонент)** - реалізація Component, до якої можна додавати нову функціональність. Основний об'єкт, який буде декоруватися.   
- **Decorator (Декоратор)** - абстрактний клас, що реалізує інтерфейс Component і зберігає посилання на інший Component. Основа для створення декораторів, делегує виклики вкладеному об'єкту.   
- **ConcreteDecorator (Конкретний декоратор)** - клас, що успадковується від Decorator і додає нову поведінку до компонента. Розширює або змінює функціональність, не змінюючи структуру основного класу.

### UML-діаграми   
**Діаграма класів**  
```mermaid
classDiagram
    class Component {
        +operation()
    }

    class ConcreteComponent {
        +operation()
    }

    class Decorator {
        -component : Component
        +Decorator(component: Component)
        +operation()
    }

    class ConcreteDecoratorA {
        +operation()
    }

    class ConcreteDecoratorB {
        +operation()
    }

    Component <|-- ConcreteComponent
    Component <|-- Decorator
    Decorator <|-- ConcreteDecoratorA
    Decorator <|-- ConcreteDecoratorB
    Decorator --> Component : wraps
```

**Діаграма взаємодії**  
```mermaid
sequenceDiagram
    participant Client
    participant Component
    participant DecoratorA
    participant DecoratorB

    Client->>DecoratorB: operation()
    DecoratorB->>DecoratorA: operation()
    DecoratorA->>Component: operation()
    Component-->>DecoratorA: результат
    DecoratorA-->>DecoratorB: результат з доповненням
    DecoratorB-->>Client: остаточний результат
```

**Діаграма станів**
```mermaid
stateDiagram-v2
    [*] --> BaseState : створення об'єкта
    BaseState --> WrappedOnce : обгортання в декоратор A
    WrappedOnce --> WrappedTwice : обгортання в декоратор B
    WrappedTwice --> ReadyToUse : об'єкт готовий до використання
    ReadyToUse --> [*]
```


## 3. Protocol Stack

**Тип шаблону:** Поведінковий (Behavioral pattern)  
**Призначення:** Забезпечує гнучке управління шарами протоколу, дозволяючи динамічно додавати або видаляти шари без необхідності змінювати інші частини стеку  
**Джерело:** [Eventhelix - Protocol Stack](https://www.eventhelix.com/design-patterns/protocol-stack/)

### Опис:
У традиційних реалізаціях стеків протоколів шари жорстко пов'язані між собою, що ускладнює їх модифікацію. Шаблон Protocol Stack розв'язує цю проблему, впроваджуючи архітектуру, де шари можуть бути динамічно додані або видалені під час виконання програми.   

**Принцип роботи:**   
1. Protocol Stack реалізується як клас, який підтримує двозв'язний список активних шарів.   
2. Кожен Protocol Layer реалізує стандартний інтерфейс для взаємодії з сусідніми шарами.   
3. Методи `Add_Layer` та `Remove_Laye`r дозволяють динамічно змінювати структуру стеку, додаючи або видаляючи шари в будь-якому місці.  
4. Методи `Handle_Transmit` та `Handle_Receive` забезпечують передачу даних через стек, делегуючи обробку відповідним шарам.   

### Основні складові:
- **Protocol Stack:** Клас, який управляє стеком протоколів, підтримуючи динамічне додавання та видалення шарів.   
- **Protocol Layer:** Базовий клас для всіх шарів протоколу, який визначає інтерфейси для взаємодії з іншими шарами.

### UML-діаграми   
**Діаграма класів**  
```mermaid
classDiagram
    class ProtocolStack {
        -layers : List<ProtocolLayer>
        +addLayer(layer: ProtocolLayer)
        +removeLayer(layer: ProtocolLayer)
        +handleTransmit(data)
        +handleReceive(data)
    }

    class ProtocolLayer {
        +setUpperLayer(layer: ProtocolLayer)
        +setLowerLayer(layer: ProtocolLayer)
        +handleTransmit(data)
        +handleReceive(data)
    }

    class ConcreteLayerA
```

**Діаграма взаємодії**  
```mermaid
sequenceDiagram
    participant App as Application
    participant Stack as ProtocolStack
    participant Layer1 as Layer A
    participant Layer2 as Layer B
    participant Layer3 as Layer C

    App->>Stack: handleTransmit(data)
    Stack->>Layer1: handleTransmit(data)
    Layer1->>Layer2: handleTransmit(data)
    Layer2->>Layer3: handleTransmit(data)
    Layer3-->>Layer2: data processed
    Layer2-->>Layer1: data processed
    Layer1-->>Stack: success
    Stack-->>App: done
```

**Діаграма станів**
```mermaid
stateDiagram-v2
    [*] --> StackInitialized
    StackInitialized --> LayersConfigured : додано шари
    LayersConfigured --> Transmitting : handleTransmit()
    Transmitting --> Receiving : handleReceive()
    Receiving --> LayersModified : шари змінено під час виконання
    LayersModified --> Transmitting
    Transmitting --> [*] : завершення передачі
```


## 4. Lock

**Тип шаблону:** Паралельні обчислення (Concurrency pattern).  
**Призначення:** Контроль одночасного доступу до спільного ресурсу, дозволяє гарантувати, що тільки один потік має доступ до ресурсу в конкретний момент часу  
**Джерело:** [Wikipedia - Lock](https://en.wikipedia.org/wiki/Lock_(computer_science))

### Опис:
Lock (Замикання) — це шаблон синхронізації, який забезпечує взаємне виключення при доступі до спільних ресурсів у багатопотоковому середовищі. Він гарантує, що тільки один потік може одночасно отримати доступ до критичної секції коду або даних, запобігаючи гонкам даних та пошкодженню стану.   
Lock використовується для ізоляції критичних ділянок коду, які не повинні виконуватись одночасно кількома потоками. Це досягається шляхом "захоплення" замка перед виконанням і "звільнення" після завершення. Інші потоки чекають, поки замок стане доступним.   

**Принцип роботи:**   
1. Потік намагається захопити замок (`lock`).   
2. Якщо замок вільний, потік отримує доступ до ресурсу.   
3. Інші потоки блокуються, поки замок не буде звільнений.  
4. Після завершення роботи потік звільняє замок (`unlock`), дозволяючи іншим потокам продовжити.   

### Основні складові:
- **Lock / Mutex / Monitor:** Примітиви синхронізації, які реалізують механізм замикання.   
- **Критична секція (Critical Section):** Фрагмент коду, який виконується під захистом замка.   
- **Condition Variable (опціонально):** Механізм, що дозволяє потокам чекати на певну умову всередині замкненої секції.   

### UML-діаграми   
**Діаграма класів**  
```mermaid
classDiagram
    class Lock {
        +lock()
        +unlock()
    }

    class Thread {
        +run()
    }

    class SharedResource {
        +use()
    }

    Thread --> Lock : uses
    Thread --> SharedResource : accesses
    SharedResource --> Lock : guarded by
```

**Діаграма взаємодії**  
```mermaid
sequenceDiagram
    participant Thread1
    participant Lock
    participant SharedResource

    Thread1->>Lock: lock()
    alt Lock доступний
        Lock-->>Thread1: success
        Thread1->>SharedResource: use()
        Thread1->>Lock: unlock()
    else Lock зайнятий
        Thread1-->>Thread1: очікування
    end
```

**Діаграма станів**
```mermaid
stateDiagram-v2
    [*] --> Unlocked
    Unlocked --> Locked : lock() викликає потік
    Locked --> Unlocked : unlock() викликає потік
    Locked --> Waiting : інший потік намагається lock()
    Waiting --> Locked : після unlock()
    Locked --> [*]
```

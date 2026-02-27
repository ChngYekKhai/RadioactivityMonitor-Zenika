# Radioactivity Monitor

## How to Run Tests

```bash
dotnet test
```

---

## Assumptions

- `Sensor` class cannot be modify, so I only added `: ISensor` to its class declaration so it can be injected into `Alarm` later.
- Modifying `Alarm` is acceptable.
- The default `Alarm()` constructor is kept intact so existing production code is unaffectedm.
- The safe range (17–21) is inclusive on both ends, based on the condition `value < LowThreshold || HighThreshold < value`.

---

## Issues Found

**1. Tight coupling to Sensor**
`Alarm` creates its own `Sensor` variable internally, making it only returns random values. I introduced an `ISensor` interface and added a constructor that accepts it, so a fake sensor can be injected with value during tests.

**2. `_alarmCount` is never exposed**
The field will increase on every unsafe reading but there is no way to read it from outside the class. I added `AlarmCount` property got get the value outside the class.

**4. Alarm never be reset**
Once triggered, `_alarmOn` is never set back to `false`. I did not add a `Reset()` method since the class is already in production, for a real plant monitor, operators likely need a way to acknowledge and clear the alarm.

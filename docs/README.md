# Microservices Patterns – Detailed Guides

This folder contains **one detailed document per pattern**. Each guide is written in a conversational style with more use cases, practical scenarios, .NET code examples, and diagrams.

For a single-page overview of all patterns, see the root document: [MICROSERVICES-PATTERNS.md](../MICROSERVICES-PATTERNS.md).

---

## Architecture & Decomposition

| Pattern | Description | Doc |
|--------|-------------|-----|
| Microservice architecture | Structure your app as small, independent services instead of one big monolith. | [01-microservice-architecture.md](01-microservice-architecture.md) |
| Decompose by business capability | Split services by what the business does (e.g. orders, payments), not by technical layers. | [02-decompose-by-business-capability.md](02-decompose-by-business-capability.md) |
| Decompose by subdomain (DDD) | Use domain-driven design: subdomains and bounded contexts define service boundaries. | [03-decompose-by-subdomain.md](03-decompose-by-subdomain.md) |
| Strangler application | Migrate from monolith to microservices gradually by replacing pieces over time. | [04-strangler-application.md](04-strangler-application.md) |

## Data & Consistency

| Pattern | Description | Doc |
|--------|-------------|-----|
| Database per service | Each service has its own database; no shared tables across services. | [05-database-per-service.md](05-database-per-service.md) |
| Saga | Keep data consistent across services with sequences of local transactions and compensations. | [06-saga-pattern.md](06-saga-pattern.md) |
| CQRS | Separate read and write models so you can scale and optimize them differently. | [07-cqrs.md](07-cqrs.md) |
| Event sourcing | Store what happened (events) instead of only current state; rebuild state by replaying. | [08-event-sourcing.md](08-event-sourcing.md) |
| API composition | Query data from multiple services and join in memory in a composer API. | [09-api-composition.md](09-api-composition.md) |
| Domain events | Publish “something happened” so other parts of the system can react without tight coupling. | [10-domain-events.md](10-domain-events.md) |

## Communication & API

| Pattern | Description | Doc |
|--------|-------------|-----|
| API Gateway | Single entry point for clients; routes and aggregates calls to backend services. | [11-api-gateway.md](11-api-gateway.md) |
| Sync vs async messaging | When to use request/response (HTTP) vs fire-and-forget or event-driven messaging. | [12-sync-vs-async-messaging.md](12-sync-vs-async-messaging.md) |
| Idempotent consumer | Make sure processing the same message twice doesn’t cause duplicate side effects. | [13-idempotent-consumer.md](13-idempotent-consumer.md) |
| Service mesh | Infrastructure for service-to-service traffic: TLS, retries, observability via sidecar proxies. | [16-service-mesh.md](16-service-mesh.md) |

## Reliability

| Pattern | Description | Doc |
|--------|-------------|-----|
| Circuit breaker | Stop calling a failing dependency so the rest of the system doesn’t collapse. | [14-circuit-breaker.md](14-circuit-breaker.md) |

## Transactional Messaging

| Pattern | Description | Doc |
|--------|-------------|-----|
| Transactional outbox | Publish messages in the same transaction as your database write so nothing gets lost. | [15-transactional-outbox.md](15-transactional-outbox.md) |

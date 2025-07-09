using Prometheus;

namespace MajesticRoutePlanner.Infrastructure.Metrics
{
    public static class CustomMetrics
    {
        /// <summary>
        /// Counts total number of route evaluations performed.
        /// </summary>
        public static readonly Counter RouteEvaluationCounter = Prometheus.Metrics
            .CreateCounter("majestic_route_evaluations_total", "Total number of route evaluations performed");

        /// <summary>
        /// Records the duration of each route evaluation (in seconds).
        /// </summary>
        public static readonly Histogram RouteEvaluationDuration = Prometheus.Metrics
            .CreateHistogram("majestic_route_evaluation_duration_seconds",
                "Time taken to evaluate optimal route");

        /// <summary>
        /// Counts the number of times a particular vehicle type was selected.
        /// </summary>
        public static readonly Counter VehicleSelectionCounter = Prometheus.Metrics
            .CreateCounter("majestic_vehicle_selection_total",
                "Counts how often each vehicle type is selected",
                new CounterConfiguration
                {
                    LabelNames = ["vehicle"]
                });

        /// <summary>
        /// Tracks how often route evaluation logic raises a warning or anomaly.
        /// </summary>
        public static readonly Counter EvaluationWarnings = Prometheus.Metrics
            .CreateCounter("majestic_route_evaluation_warnings_total",
                "Counts how many times route evaluation triggered a warning");
    }
}
import tensorflow as tf

# copy from https://github.com/tensorflow/models/blob/master/official/transformer/utils/metrics.py


def padded_cross_entropy_loss(logits, labels, smoothing, vocab_size):
    """Calculate cross entropy loss while ignoring padding.
    Args:
      logits: Tensor of size [batch_size, length_logits, vocab_size]
      labels: Tensor of size [batch_size, length_labels]
      smoothing: Label smoothing constant, used to determine the on and off values
      vocab_size: int size of the vocabulary
    Returns:
      Returns the cross entropy loss and weight tensors: float32 tensors with
        shape [batch_size, max(length_logits, length_labels)]
    """
    with tf.name_scope("loss" ):# , values=[logits, labels]
        logits, labels = _pad_tensors_to_same_length(logits, labels)

        # Calculate smoothing cross entropy
        with tf.name_scope("smoothing_cross_entropy"):# , values=[logits, labels]
            confidence = 1.0 - smoothing
            low_confidence = (1.0 - confidence) / tf.cast(vocab_size - 1 , tf.float32)
            soft_targets = tf.one_hot(
                tf.cast(labels, tf.int32),
                depth=vocab_size,
                on_value=confidence,
                off_value=low_confidence)
            xentropy = tf.nn.softmax_cross_entropy_with_logits(
                logits=logits, labels=soft_targets)

            # Calculate the best (lowest) possible value of cross entropy, and
            # subtract from the cross entropy loss.
            normalizing_constant = -(
                confidence * tf.math.log(confidence) + tf.cast(vocab_size - 1 , tf.float32) *
                low_confidence * tf.math.log(low_confidence + 1e-20))
            xentropy -= normalizing_constant

        weights = tf.cast(tf.not_equal(labels, 0),tf.float32)
        return xentropy * weights, weights


def padded_accuracy(logits, labels):
    """Percentage of times that predictions matches labels on non-0s."""
    with tf.compat.v1.variable_scope("padded_accuracy"): # , values=[logits, labels]):
        logits, labels = _pad_tensors_to_same_length(logits, labels)
        weights = tf.cast(tf.not_equal(labels, 0),tf.float32)
        outputs = tf.cast(tf.argmax(logits, axis=-1),tf.int32)
        padded_labels = tf.cast(labels , tf.int32)
        return tf.cast(tf.equal(outputs, padded_labels), tf.float32), weights


def _pad_tensors_to_same_length(x, y):
    """Pad x and y so that the results have the same length (second dimension)."""
    with tf.name_scope("pad_to_same_length"):
        x_length = tf.shape(x)[1]
        y_length = tf.shape(y)[1]

        max_length = tf.maximum(x_length, y_length)

        x = tf.pad(x, [[0, 0], [0, max_length - x_length], [0, 0]])
        y = tf.pad(y, [[0, 0], [0, max_length - y_length]])
        return x, y

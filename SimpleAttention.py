import tensorflow as tf
 
class SimpleAttention(tf.keras.models.Model):
    def __init__(self,depth:int,*args,**kwargs):
        super().__init__(*args,**kwargs)
        self.depth = depth
        self.q_dense_layer = tf.keras.layers.Dense(depth,use_bias = False,name = 'q_dense_layer')
        self.k_dense_layer = tf.keras.layers.Dense(depth,use_bias = False,name = 'k_dense_layer')
        self.v_dense_layer = tf.keras.layers.Dense(depth,use_bias = False,name = 'v_dense_layer')
        self.output_dense_layer = tf.keras.layers.Dense(depth,use_bias = False,name = 'output_dense_layer')
        
        def call(self,input:tf.Tensor,memory:tf.Tensorn) -> tf.Tensor:
            
            q = self.q_dense_layer(input)
            k = self.k_dense_layer(memory)
            v = self.v_dense_layer(memory)
            
            logit = tf.matmul(q,k,transpose_b = True)
            
            attention_weight = tf.nn.softmax(logit,name ='attention_weight' )
            
            attention_output = tf.matmul(attention_weight,v)
            return self.output_dense_layer(attention_output)
            
        
                    
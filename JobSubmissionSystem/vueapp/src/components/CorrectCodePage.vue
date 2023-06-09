<template>

    <el-aside id="treeView">
        <el-tree v-show="treeView" :data="treeView" :props="treeProps" @node-click="FileTreeClick">

        </el-tree>
    </el-aside>
    <el-main style="height: 70%;">
        
        <el-card class="box-card">

            <template #header>
                <div class="card-header">
                    <span>{{filename}}</span>
                    <el-button class="button" @click="submit" text>提交</el-button>
                </div>
            </template>
            
            <el-scrollbar style = "height: 65vh;">
            <el-text id="code">
                <el-text v-for="(data,index) in code_data" :key="index" @mouseup.stop="process($event,index)">
                    <el-text v-if="!data.flagged" color="red">
                        {{data.code}}
                    </el-text>
                    <el-popover v-else
                        placement="top-start"
                        title="批改"
                        :width="200"
                        trigger="hover"
                        :content="data.correct_info"
                    >
                        <template #reference>
                            <el-text type="danger" @click="changeDesc(index)">
                                {{data.code}}
                            </el-text>
                        </template>
                    </el-popover>
                </el-text>
            </el-text>
            </el-scrollbar>
        </el-card>
    </el-main>
</template>

<script>
    import axios from '../../api/config'
    import { ElMessage, ElMessageBox } from 'element-plus'
    export default {
        name: "CodePage",

        data() {
            return {
                treeView: null,
                treeProps: {
                    children: 'children',
                    label: 'name'
                },
                code_data: [
                    {
                        code: "禁用页面的拖拽方法，防止文字选中功能被覆盖",
                        flagged: false,
                        correct_info: ""
                    },

                ],
                orgin_code: "",
                filename: null
            }
        },
        mounted() {
            //禁用页面的拖拽方法，防止文字选中功能被覆盖
            window.addEventListener("dragstart", (e) => {
                e.preventDefault();
                e.stopPropagation();
            });
        },

        methods: {
            //处理点击文件树事件
            FileTreeClick(data) {
                this.file_inf = data.f;
                console.log(data.f.rawUrl)
                if(data.f.rawUrl == null){
                    return;
                }
            
                axios({
                    method: 'POST',
                    url: 'api/submitCorrect/getFile',
                    params: {
                        url: data.f.rawUrl,
                    }
                }).then(
                    response => {
                        console.log(response.data);
                        this.code_data = [
                            {
                                code: response.data,
                                flagged: false,
                                correct_info: ""
                            },
                        ]
                    }, error => {
                        console.log(error)
                    }
                )
                this.$forceUpdate();
            },
            //处理选中事件
            process(event, index) {
                if (!window.getSelection().toString()) {
                    return
                }
                //阻止事件冒泡
                //不仅仅要stopPropagation，还要preventDefault
                function pauseEvent(e) {
                    if (e.stopPropagation) e.stopPropagation();
                    if (e.preventDefault) e.preventDefault();
                    e.cancelBubble = true;
                    e.returnValue = false;
                    return false;
                }
                var start_pos = window.getSelection().anchorOffset;
                var end_pos = window.getSelection().focusOffset;
                var code_slice = this.code_data[index].code;
                if (!code_slice.includes(window.getSelection().toString())) {
                    return
                }
                var str1 = code_slice.substring(0, start_pos)
                var str2 = code_slice.substring(start_pos, end_pos)
                var str3 = code_slice.substring(end_pos, code_slice.length)
                console.log(str1 + "\n")
                console.log(str2 + "\n")
                console.log(str3 + "\n")
                //更改代码,这个窗口不会含有默认值
                ElMessageBox.prompt('请输入批改内容', '批改', {
                    confirmButtonText: 'OK',
                    cancelButtonText: 'Cancel',

                }).then(({ value }) => {
                    ElMessage({
                        type: 'success',
                        message: '批改成功',
                    })
                    this.code_data.splice(index, 1, { code: str1, flagged: false, correct_info: "" },
                        { code: str2, flagged: true, correct_info: value }, { code: str3, flagged: false, correct_info: "" })
                }).catch(() => {
                    ElMessage({
                        type: 'info',
                        message: '取消批改',
                    })
                })

                pauseEvent(event);
                console.log(this.treeView);
            },
            changeDesc(index) {
                ElMessageBox.prompt('请修改批改内容', '修改', {

                    confirmButtonText: 'OK',
                    cancelButtonText: 'Cancel',
                    inputValue: this.code_data[index].correct_info

                }).then(({ value }) => {
                    ElMessage({
                        type: 'success',
                        message: '修改成功',
                    })
                    if (value == "") {
                        ElMessage({
                            type: 'warning',
                            message: '您删除了一条批改记录',
                        })
                        this.code_data[index].flagged = false;
                    }
                    this.code_data[index].correct_info = value;
                }).catch(() => {
                    ElMessage({
                        type: 'info',
                        message: '取消修改',
                    })
                })
            },
            submit(){
                var q = this.$route.query
                console.log(this.code_data)
                var text = JSON.stringify(this.code_data)
                console.log(text)
                const pa = {
                        courseId:q.classId,
                        studentId:q.studentId,
                        workIndex:q.workIndex,
                        filepath:this.file_inf.path,
                        jsonStr:text
                    }
                axios({
                    method: 'POST',
                    url: 'api/submitCorrect',
                    params: pa
                })
                .then(response => {
                    console.log(response.data)
                    if(response.data == 1){
                        ElMessage({
                            type: 'success',
                            message: '提交成功',
                        })
                    }else{
                        ElMessage({
                            type: 'error',
                            message: '未知的错误，请联系管理员',
                        })
                    }
                }, error => {
                    ElMessage({
                        type: 'error',
                        message: '未知的错误，请联系管理员',
                    })
                })
            }
        },
        created() {
           
            var q = this.$route.query
            //console.log(this.treeView)
            axios.get('api/CorrectionInfor?courseId='+q.classId+'&studentId='+q.studentId+'&assignmentIndex='+q.workIndex).then(
                response => {
                    this.treeView = [response.data];
                    this.treeView = JSON.parse(JSON.stringify(this.treeView))
                    console.log(this.treeView)
                }
            )

        }
    };
</script>

<style>
    #treeView {
        width: 250px;
        float: Left;
    }

    #code {
        white-space: pre;
        width: 100%;
        outline: none;
        min-width: 600px;
    }

    .card-header {
        height: 5vh;
    }

    .box-card {
        height: 80vh;
    }
</style>